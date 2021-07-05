
using Javsdt.Shared;
using Javsdt.Shared.Enum;
using Javsdt.Shared.Model.Client;
using Javsdt.Shared.Model.SQL;
using Javsdt.Shared.Model.SQL.Middle;
using Javsdt.Shared.Model.SQL.Property;
using Javsdt.SQL.Init;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Javsdt.SQL.Json
{
    public class WriteWorker
    {
        public static void WriteJsonToDb(string newJsonsDirectory)
        {

            List<string> jsons = FileExplorer.GetAllSubFilesPaths(newJsonsDirectory, new List<string> { }, ".json");
            foreach (string jsonPath in jsons)
            {
                // 读取文件内容
                string myJsonString = File.ReadAllText(jsonPath);
                // 解析json为MovieJson类
                MovieJson movieJson = JsonConvert.DeserializeObject<MovieJson>(myJsonString);
                // 如果json文件没有数据，json无效，移动错误的json
                if (movieJson == null)
                {
                    string jsonErrorpath = Path.Combine(EnvSettings.ErrorJsonsPath, Path.GetFileName(jsonPath));
                    File.Move(jsonPath, jsonErrorpath);
                    continue;
                };
                Console.WriteLine(movieJson.Car);

                // 添加新影片到数据库;
                Task.Run(async () => await AddNewMovieAsync(movieJson)).Wait();

                //Movie movieSearch = context.Movies.FirstOrDefault(m => m.Id == mj.dmm_id);
                //if (movieSearch == null)
                //{
                //    AddNewMovie(mj);
                //}
                //// 如果数据库已收纳该车牌的信息，则跳过
                //else
                //{
                //    Console.WriteLine("数据库已收纳！");
                //}
            }

        }

        public static async Task AddNewMovieAsync(MovieJson mj)
        {
            using JavsdtContext context = new();

            // ====车牌去除左边的0====
            string[] carArrary = mj.Car.Split("-");
            string carPrefString = carArrary[0];
            string carSufString = carArrary[1].TrimStart('0');    //.TrimStart('0');
                                                   //carSufString = Regex.Replace(carSufString, "[a-z]", "");

            // ====车牌前缀====
            // 数据库还不存在该车牌前缀
            if (context.CarPrefs.FirstOrDefault(carpref => carpref.Name == carPrefString) == null)
            {
                context.CarPrefs.Add(new CarPref { Name = carPrefString });
            }

            // 年份
            string release = (string.IsNullOrEmpty(mj.Release)) ? "1970-01-01" : mj.Release;

            // ====由MovieJson转换为Movie====
            Movie movie = new Movie
            {
                // 1
                Car = mj.Car,
                // 2
                CarOrigin = string.IsNullOrEmpty(mj.CarOrigin) ? null : mj.CarOrigin,
                // 3
                CarPref = carPrefString,
                // 4
                CarSuf = int.Parse(carSufString),
                // 5
                Title = mj.Title,
                // 6
                TitleZh = (string.IsNullOrEmpty(mj.TitleZh)) ? null : mj.TitleZh,
                // 7
                Plot = (string.IsNullOrEmpty(mj.Plot)) ? null : mj.Plot,
                // 8
                PlotZh = (string.IsNullOrEmpty(mj.PlotZh)) ? null : mj.PlotZh,
                // 9
                Review = (string.IsNullOrEmpty(mj.Review)) ? null : mj.Review,
                // 10
                Score = mj.Score,
                // 11
                Runtime = mj.Runtime,
                // 12
                Year = int.Parse(release.Substring(0, 4)),
                // 13
                Release = DateTime.ParseExact(release, "yyyy-MM-dd", CultureInfo.CurrentCulture),
                // 14 封面Library
                CoverLibrary = (string.IsNullOrEmpty(mj.CoverLibrary)) ? null : mj.CoverLibrary,
                // 15 封面Bus
                CoverBus = (string.IsNullOrEmpty(mj.CoverBus)) ? null : mj.CoverBus,
                // 16
                CutType = mj.CutType,

                // 17
                Javdb = (string.IsNullOrEmpty(mj.Javdb)) ? null : mj.Javdb,
                // 18
                Javlibrary = (string.IsNullOrEmpty(mj.Javlibrary)) ? null : mj.Javlibrary,
                // 19
                Javbus = (string.IsNullOrEmpty(mj.Javbus)) ? null : mj.Javbus,
                // 20
                Arzon = (string.IsNullOrEmpty(mj.Arzon)) ? null : mj.Arzon,

                // 22 完成度，三大网站为全部
                Completion = mj.Completion,
                // 23 版本
                Version = mj.Version,
            };

            #region 系列
            mj.Series = (string.IsNullOrEmpty(mj.Series)) ? "未知Series" : mj.Series;    // 去数据库搜寻的系列
            Series seriesAlready = context.Serieses.FirstOrDefault(series => series.Name == mj.Series);    // 数据库搜寻到的系列
            // 数据库还不存在该系列
            if (seriesAlready == null)
            {
                movie.Series = new Series { Name = mj.Series };
            }
            else
            {
                movie.Series = seriesAlready;
            }
            #endregion

            #region 演职人员
            if (mj.Actors.Contains(mj.Director))
            {
                mj.Director = (string.IsNullOrEmpty(mj.Director)) ? "未知Director" : mj.Director;
                Cast castAlready = context.Casts.FirstOrDefault(cast => cast.Name == mj.Director);    // 数据库搜寻到的发行商
                MovieCast movieCast = new() { Type = CastType.Both };
                // 数据库还不存在该导演
                if (castAlready == null)
                {
                    movieCast.Cast = new Cast { Name = mj.Director };
                }
                else
                {
                    movieCast.Cast = castAlready;
                }
                movie.MovieCasts.Add(movieCast);
                mj.Actors.Remove(mj.Director);
            }
            else
            {
                // =====导演====
                mj.Director = (string.IsNullOrEmpty(mj.Director)) ? "未知Director" : mj.Director;
                Cast directorAlready = context.Casts.FirstOrDefault(cast => cast.Name == mj.Director);    // 数据库搜寻到的发行商
                MovieCast movieDirector = new() { Type = CastType.Director };
                // 数据库还不存在该导演
                if (directorAlready == null)
                {
                    movieDirector.Cast = new Cast { Name = mj.Director };
                }
                else
                {
                    movieDirector.Cast = directorAlready;
                }
                movie.MovieCasts.Add(movieDirector);
            }
            // ==== 演员 ====
            foreach (string actorSearch in mj.Actors)
            {
                Cast actorAlready = context.Casts.FirstOrDefault(a => a.Name == actorSearch);
                MovieCast movieActor = new() { Type = CastType.Actress };
                // 数据库还不存在该【演员】，添加它
                if (actorAlready == null)
                {
                    movieActor.Cast = new Cast { Name = actorSearch };
                }
                else
                {
                    movieActor.Cast = actorAlready;
                }
                movie.MovieCasts.Add(movieActor);
            }
            #endregion

            #region 制作公司
            if (mj.Studio == mj.Publisher)
            {
                mj.Studio = (string.IsNullOrEmpty(mj.Studio)) ? "未知Company" : mj.Studio;    // 去数据库搜寻的片商名称
                Company companyAlready = context.Companys.FirstOrDefault(company => company.Name == mj.Studio);    // 数据库搜寻到的片商
                MovieCompany movieCompany = new() { Type = CompanyType.Both };
                // 数据库还不存在该片商
                if (companyAlready == null)
                {
                    movieCompany.Company = new Company { Name = mj.Studio };
                }
                else
                {
                    movieCompany.Company = companyAlready;
                }
                movie.MovieCompanys.Add(movieCompany);
            }
            else
            {
                // =====片商====
                mj.Studio = (string.IsNullOrEmpty(mj.Studio)) ? "未知Company" : mj.Studio;    // 去数据库搜寻的片商名称
                Company studioAlready = context.Companys.FirstOrDefault(company => company.Name == mj.Studio);    // 数据库搜寻到的片商
                MovieCompany movieStudio = new() { Type = CompanyType.Producer };
                // 数据库还不存在该片商
                if (studioAlready == null)
                {
                    movieStudio.Company = new Company { Name = mj.Studio };
                }
                else
                {
                    movieStudio.Company = studioAlready;
                }
                movie.MovieCompanys.Add(movieStudio);

                // =====发行商====
                mj.Publisher = (string.IsNullOrEmpty(mj.Publisher)) ? "未知Company" : mj.Publisher;    // 去数据库搜寻的发行商名称
                Company publisherAlready = context.Companys.FirstOrDefault(company => company.Name == mj.Publisher);    // 数据库搜寻到的发行商
                MovieCompany moviePublisher = new() { Type = CompanyType.Publisher };    // 即将赋给movie的publisher
                                                                                         // 数据库还不存在该发行商
                if (publisherAlready == null)
                {
                    moviePublisher.Company = new Company { Name = mj.Publisher };
                }
                else
                {
                    moviePublisher.Company = publisherAlready;
                }
                movie.MovieCompanys.Add(moviePublisher);
            }
            #endregion

            #region 特征和标签
            // ==== 特征 ====
            foreach (string genreSearch in mj.Genres)
            {
                Genre genreAlready = context.Genres.FirstOrDefault(g => g.NameZh == genreSearch);
                MovieGenre movieGenre = new();
                // 数据库还不存在该【特征】，添加它
                if (genreAlready == null)
                {
                    movieGenre.Genre = new Genre { NameZh = genreSearch };
                }
                else
                {
                    movieGenre.Genre = genreAlready;
                }
                movie.MovieGenres.Add(movieGenre);
            }
            #endregion

            // 收集完毕
            context.Movies.Add(movie);
            await context.SaveChangesAsync();
        }
    }
}
