using Javasdt.Shared.Models.SQL;
using System;
using HtmlAgilityPack;
using System.Net;
using Javasdt.Shared.Statics;
using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Scrape;
using System.Text.RegularExpressions;
using Javasdt.Shared.Exceptions;
using Javasdt.Collector.Handlers.Metadata;

namespace Javasdt.Collector.Handlers.Web
{
    public class DbHandler : IWebHandler
    {
        private readonly string UrlDb;
        private readonly WebProxy Proxy;
        private const string Web = "javdb";

        public DbHandler(string urlDb, WebProxy proxy)
        {
            UrlDb = urlDb;
            Proxy = proxy;
        }

        public HtmlDocument GetHtml(string url)
        {
            HtmlWeb web = new ();
            for (int retry = 0; retry < 10; retry++)
            {
                HtmlDocument htmlDocument = web.Load(url, "GET", Proxy, null);
                //通过判断返回内容的标题，来判断是否成功找出
                try
                {
                    htmlDocument.DocumentNode.SelectSingleNode("//title");
                    return htmlDocument;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception:\n{e}\n BaseException:\n{e.GetBaseException()} \n GetType:\n{e.GetType()} \nMessage:\n{e.Message}\n StackTrace:\n{e.StackTrace}");
                    continue;
                }
            }
            Console.WriteLine(Commons.NetworkErrorMsg(url));
            Console.ReadKey();
            throw new NetworkException();
        }

        public ScrapeStatusEnum Scrape(MovieFile movieFile, MovieModel movieModel)
        {
            string urlOnDb;
            string javadb;
            //用户指定了网址，则直接得到jav所在网址
            if (movieFile.Name.Contains(Commons.DbSpecifiedUrl))
            {
                Match match = Regex.Match(movieFile.Name, Commons.DbSpecifiedRegex);
                if (!match.Success)
                {
                    throw new SpecifiedUrlException($"{Commons.DbSpecifiedErrorMsg}");
                }
                javadb = match.Groups[1].Value;
                urlOnDb = $"{UrlDb}/v/{javadb}";
                HtmlDocument htmlDocument = GetHtml(urlOnDb);
                string webTitle = htmlDocument.DocumentNode.SelectSingleNode("//title").InnerText;
                if (!webTitle.Contains(Commons.DbTitleNormalPart))
                {
                    throw new SpecifiedUrlException($"{Commons.DbSpecifiedErrorMsg}");
                }
            }
            //用户没有指定网址，则去搜索
            else
            {
                //当前车牌的车头、车尾
                string[] carSplits = movieFile.Car.Split("-");
                string prefCurrent = carSplits[0];
                int sufCurrent = int.Parse(CarHandler.ExtractNumberFromCarSuf(carSplits[1]));
            }



            throw new NotImplementedException();
        }
    }
}