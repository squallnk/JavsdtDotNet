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
    public class GetController : ControllerBase
    {
        private readonly GetRepository _getRepository;

        public GetController(GetRepository getRepository)
        {
            _getRepository = getRepository;
        }

        // 1 依据Car获取某个Movie的详情
        [HttpGet("api/movie/{car}/language/{isPreferZh}")]
        public async Task<MovieDetail[]> GetMoviesByCar(string car, bool isPreferZh)
        {
            MovieDetail[] movies = await _getRepository.GetMoviesByCar(car.ToUpper(), isPreferZh);
            foreach (MovieDetail movie in movies)
            {
                Task<CastPreview[]> castTask = _getRepository.GetCastsByMovieId(movie.Id);
                Task<CompanyPreview[]> companyTask = _getRepository.GetCompanysByMovieId(movie.Id);
                Task<string[]> genreTask = _getRepository.GetGenresByMovieId(movie.Id);
                Task<string[]> tagTask = _getRepository.GetTagsByMovieId(movie.Id);
                await Task.WhenAll(companyTask, castTask, genreTask, tagTask);
                movie.Casts = await castTask;
                movie.Companys = await companyTask;
                movie.Genres = await genreTask;
                movie.Tags = await tagTask;
            }
            return movies;
        }
    }
}
