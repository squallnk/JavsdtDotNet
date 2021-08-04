using Javasdt.API.Common.Response;
using Javasdt.API.SQL;
using Javasdt.API.Utility.Safe;
using Javasdt.Shared.DTO;
using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Javasdt.API.Controllers
{
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MyRepository _myRepository;
        private IMemoryCache _cache;
        private MemoryCacheEntryOptions _cacheEntryOptions;

        public MyController(MyRepository myRepository, IConfiguration config, IMemoryCache cache)
        {
            _config = config;
            _myRepository = myRepository;
            _cache = cache;
            _cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(3));
        }

        // 0 获取当前数据库收纳的条数
        [HttpGet("api/movies/amount")]
        public string GetMoviesAmount()
        {
            int amount = _myRepository.CountMoviesAmount();
            return $"当前收纳: {amount}条";
        }

        // 1 依据Car获取某个Movie的详情
        [HttpPost("api/movies/search")]
        //[TypeFilter(typeof(MovieSearchResourceFilterAttribute))]
        public async Task<MyResult> GetMoviesByCar([FromBody] MoviesSearch moviesSearch)
        {
            #region 验证
            string rsaVerification = moviesSearch.RsaVerification;
            if (! RsaHandler.IsValidClient(rsaVerification, _config["ServerIdentity"], _config["RsaPrivateKey"]))
            {
                return new MyResult(ResultStatusEnum.Unauthorized);
            }
            #endregion

            string car = moviesSearch.Car.ToUpper();
            //Console.WriteLine($"正在处理: {car}");
            //Console.WriteLine($"客户端验证: {rsaVerification}");

            // Look for cache key.
            if (!_cache.TryGetValue(car, out MovieRes[] movies))
            {
                movies = await _myRepository.SelectMoviesByCar(car);
                foreach (MovieRes movie in movies)
                {
                    Task<CastPreview[]> castTask = _myRepository.SelectCastsByMovieId(movie.Id);
                    Task<CompanyPreview[]> companyTask = _myRepository.SelectCompanysByMovieId(movie.Id);
                    Task<string[]> genreTask = _myRepository.SelectGenresByMovieId(movie.Id);
                    Task<string[]> tagTask = _myRepository.SelectTagsByMovieId(movie.Id);
                    await Task.WhenAll(companyTask, castTask, genreTask, tagTask);
                    movie.Casts = await castTask;
                    movie.Companys = await companyTask;
                    movie.Genres = await genreTask;
                    movie.Tags = await tagTask;
                }
                // Save data in cache.
                _cache.Set(car, movies, _cacheEntryOptions);
            }

            return new MyResult(ResultStatusEnum.Success, movies);
        }

        // 2 依据Car获取某个Movie的详情
        [HttpPost("api/movies/create")]
        public MyResult CreateMovie([FromBody] MovieNew movieNew)
        {
            #region 验证
            string rsaVerification = movieNew.RsaVerification;
            if (!RsaHandler.IsValidClient(rsaVerification, _config["ServerIdentity"], _config["RsaPrivateKey"]))
            {
                return new MyResult(ResultStatusEnum.Unauthorized);
            }
            #endregion

            MovieModel movieJson = movieNew;
            try
            {
                _myRepository.AddMovie(movieJson);
            }
            catch (Exception)
            {
                Console.WriteLine("新增movie入库失败！");
                return new MyResult(ResultStatusEnum.SqlError);
            }
            _cache.Remove(movieNew.Car);
            return new MyResult(ResultStatusEnum.Success);
        }

    }
}
