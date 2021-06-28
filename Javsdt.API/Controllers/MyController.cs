using Javsdt.API.SQL;
using Javsdt.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javsdt.API.Controllers
{
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly MyRepository _myRepository;

        public MyController(MyRepository myRepository)
        {
            _myRepository = myRepository;
        }

        // 1 依据Car获取某个Movie的详情
        [HttpPost("api/movies/search")]
        public async Task<MovieRes[]> GetMoviesByCar([FromBody]string car)
        {
            Console.WriteLine($"正在处理: {car}");
            MovieRes[] movies = await _myRepository.SelectMoviesByCar(car.ToUpper());
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

        // 2 获取当前数据库收纳的条数
        [HttpGet("api/movies/amount")]
        public string GetMoviesAmount()
        {
            int amount = _myRepository.CountMoviesAmount();
            return $"当前收纳: {amount}条";
        }
    }
}
