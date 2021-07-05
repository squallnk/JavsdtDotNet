using Javsdt.API.SQL;
using Javsdt.API.Utility.Safe;
using Javsdt.Shared.DTO;
using Javsdt.Shared.Model.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Javsdt.API.Controllers
{
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MyRepository _myRepository;

        public MyController(MyRepository myRepository, IConfiguration config)
        {
            _config = config;
            _myRepository = myRepository;
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
        public async Task<ActionResult<MovieRes[]>> GetMoviesByCar([FromBody] MoviesSearch moviesSearch)
        {
            string rsaVerification = moviesSearch.RsaVerification;
            if (! RsaHandler.IsValidClient(rsaVerification, _config["ServerIdentity"], _config["RsaPrivateKey"]))
            {
                return Unauthorized();
            }
            string car = moviesSearch.Car.ToUpper();
            //Console.WriteLine($"正在处理: {car}");
            //Console.WriteLine($"客户端验证: {rsaVerification}");
            MovieRes[] movies = await _myRepository.SelectMoviesByCar(car);
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
            return movies;
        }

        // 2 依据Car获取某个Movie的详情
        [HttpPost("api/movies/create")]
        public async Task<ActionResult<MovieJson>> CreateMovie([FromBody] MovieNew movieNew)
        {
            string rsaVerification = movieNew.RsaVerification;
            if (!RsaHandler.IsValidClient(rsaVerification, _config["ServerIdentity"], _config["RsaPrivateKey"]))
            {
                return Unauthorized();
            }
            if (_myRepository.ExistMovieByCarOrigin(movieNew.Car))
            {
                return Accepted();
            }
            MovieJson movieJson = movieNew;
            await _myRepository.AddMovieAsync(movieJson);
            return Ok();
        }

    }
}
