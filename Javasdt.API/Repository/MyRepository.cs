using Javasdt.Shared.DTO;
using Javasdt.Shared.Models.Client;
using Javasdt.SQL.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Javasdt.API.SQL
{
    public class MyRepository
    {
        private readonly JavasdtContext _context;

        public MyRepository(JavasdtContext context)
        {
            _context = context;
        }

        public async Task<MovieRes[]> SelectMoviesByCar(string car)
        {
            MovieRes[] movies = await _context.Movies.Where(movie => movie.Car == car)
                                        .Select(movie => new MovieRes
                                        {
                                            Id = movie.Id,                       // 0 Id
                                            Car = car,                           // 1 车牌
                                            CarOrigin = movie.CarOrigin,         // 2 车牌
                                            Title = movie.Title,                 // 5 原标题
                                            TitleZh = movie.TitleZh,             // 6 简体中文标题
                                            Plot = movie.Plot,                   // 7 剧情概述
                                            PlotZh = movie.PlotZh,               // 8 简体剧情
                                            Review = movie.Review,               // 9 简体剧情
                                            Score = movie.Score,                 // 10 评分 10倍
                                            Runtime = movie.Runtime,             // 11 时长
                                            Year = movie.Year,                   // 12 发行年份
                                            Release = movie.Release,             // 13 发行日期
                                            CoverLibrary = movie.CoverLibrary,   // 14 封面Library
                                            CoverBus = movie.CoverBus,           // 15 封面Bus
                                            CutType = movie.CutType,             // 16 裁剪方式
                                            Javdb = movie.Javdb,                 // 17 db编号
                                            Javlibrary = movie.Javlibrary,       // 18 library编号
                                            Javbus = movie.Javbus,               // 19 bus编号
                                            Arzon = movie.Arzon,                 // 20 arzon编号
                                            Series = movie.Series == null ? null : movie.Series.Name,    // 21 系列 【引用导航】
                                            CompletionStatus = movie.CompletionStatus,       // 22 完成度，三大网站为全部
                                            Version = movie.Version,             // 23 版本
                                        }).ToArrayAsync();
            return movies;
        }

        internal bool ExistMovieByCarOrigin(string car)
        {
            if (string.IsNullOrEmpty(car))
            {
                return true;
            }
            else
            {
                if (_context.Movies.FirstOrDefault(movie => movie.Car == car) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal int CountMoviesAmount()
        {
            return _context.Movies.Count();
        }

        public async Task<CompanyPreview[]> SelectCompanysByMovieId(int id)
        {
            CompanyPreview[] companys = await _context.MovieCompanys.Where(movieCompany => movieCompany.MovieId == id)
                                                                        .Select(movieCompany => new CompanyPreview
                                                                        {
                                                                            Name = movieCompany.Company.Name,
                                                                            Type = movieCompany.Type,
                                                                        })
                                                                        .ToArrayAsync();
            return companys;
        }

        public void AddMovie(MovieModel movieJson)
        {
            WriteWorker.AddNewMovie(movieJson);
        }

        public async Task<CastPreview[]> SelectCastsByMovieId(int id)
        {
            CastPreview[] casts = await _context.MovieCasts.Where(movieCast => movieCast.MovieId == id)
                                                        .Select(movieCast => new CastPreview
                                                        {
                                                            Name = movieCast.Cast.Name,
                                                            Type = movieCast.Type,
                                                        })
                                                        .ToArrayAsync();
            return casts;
        }

        public async Task<string[]> SelectGenresByMovieId(int id)
        {
            string[] genres = await _context.MovieGenres.Where(movieGenre => movieGenre.MovieId == id)
                                                        .Select(movieGenre => movieGenre.Genre.NameZh)
                                                        .ToArrayAsync();
            return genres;
        }

        public async Task<string[]> SelectTagsByMovieId(int id)
        {
            string[] tags = await _context.MovieTags.Where(movieTag => movieTag.MovieId == id)
                                                        .Select(movieTag => movieTag.Tag.NameZh)
                                                        .ToArrayAsync();
            return tags;
        }




    }
}
