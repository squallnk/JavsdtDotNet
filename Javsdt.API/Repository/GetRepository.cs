using Javsdt.SQL.Init;
using Javsdt.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Javsdt.API.SQL
{
    public class GetRepository
    {
        private readonly JavsdtContext _context;

        public GetRepository(JavsdtContext context)
        {
            _context = context;
        }

        public async Task<MovieDetail[]> GetMoviesByCar(string car, bool isPreferZh)
        {
            MovieDetail[] movies = await _context.Movies.Where(movie => movie.Car == car)
                                        .Select(movie => new MovieDetail
                                        {
                                            Id = movie.Id,
                                            Car = car,
                                            CarOrigin = movie.CarOrigin,
                                            Title = isPreferZh ? movie.TitleZh : movie.Title,
                                            Plot = isPreferZh ? movie.PlotZh : movie.Plot,
                                            Score = movie.Score,
                                            Runtime = movie.Runtime,
                                            Year = movie.Year,
                                            Release = movie.Release,
                                            FanartBase64 = movie.FanartBase64,
                                            PosterCutType = movie.CutType,
                                            LibraryId = movie.Javlibrary,
                                            BusId = movie.Javbus,
                                            DbId = movie.Javdb,
                                            ArzonId = movie.Arzon,
                                            TimeModify = movie.TimeModify,
                                            Series = movie.Series == null ? null : movie.Series.Name,
                                        }).ToArrayAsync();
            return movies;
        }

        public async Task<CompanyPreview[]> GetCompanysByMovieId(int id)
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

        public async Task<CastPreview[]> GetCastsByMovieId(int id)
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

        public async Task<string[]> GetGenresByMovieId(int id)
        {
            string[] genres = await _context.MovieGenres.Where(movieGenre => movieGenre.MovieId == id)
                                                        .Select(movieGenre => movieGenre.Genre.NameZh)
                                                        .ToArrayAsync();
            return genres;
        }

        public async Task<string[]> GetTagsByMovieId(int id)
        {
            string[] tags = await _context.MovieTags.Where(movieTag => movieTag.MovieId == id)
                                                        .Select(movieTag => movieTag.Tag.NameZh)
                                                        .ToArrayAsync();
            return tags;
        }




    }
}
