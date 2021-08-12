using Javasdt.Shared.Models.SQL;
using System;
using HtmlAgilityPack;
using System.Net;
using Javasdt.Shared.Statics;
using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Scrape;
using System.Text.RegularExpressions;
using Javasdt.Shared.Exceptions;
using Javasdt.Scrape.Handlers.Metadata;
using System.Linq;

namespace Javasdt.Scrape.Handlers.Web
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

        public HtmlDocument GetHtmlDocument(string url)
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
            string javdb;
            //用户指定了网址，则直接得到jav所在网址
            if (movieFile.Name.Contains(Commons.DbSpecifiedUrl))
            {
                Match match = Regex.Match(movieFile.Name, Commons.DbSpecifiedRegex);
                if (!match.Success)
                {
                    throw new SpecifiedUrlException($"{Commons.DbSpecifiedErrorMsg}");
                }
                javdb = match.Groups[1].Value;
                urlOnDb = $"{UrlDb}/v/{javdb}";
                HtmlDocument htmlDocument = GetHtmlDocument(urlOnDb);
                string webTitle = htmlDocument.DocumentNode.SelectSingleNode("//title").InnerText;
                if (!webTitle.Contains(Commons.DbTitleNormalPart))
                {
                    throw new SpecifiedUrlException($"{Commons.DbSpecifiedErrorMsg}");
                }
            }
            //用户没有指定网址，则去搜索
            else
            {
                //当前车头、车尾
                string[] carSplits = movieFile.Car.Split("-");
                string prefCurrent = carSplits[0];
                int sufCurrent = CarHandler.ExtractNumberFromCarSuf(carSplits[1]);
                //当前检查的第几页，当前页面的最小车尾
                int noPage = 1;
                int sufMin;
                int sufMax;
                HtmlDocument htmlDocument;
                //车头的第一页
                string urlCodePage = Commons.UrlDbCodePage(UrlDb, prefCurrent, noPage);
                //第一页上的所有box
                HtmlNode[] carsNodes = GetCarsHtmlNodes(GetHtmlDocument(urlCodePage));
                if (carsNodes.Length == 0)
                {
                    return ScrapeStatusEnum.Db_not_found;
                }
                else
                {
                    //第一页的末尾，即最小suf
                    sufMin = CarHandler.ExtractNumberFromCarSuf(carsNodes[0].InnerText);
                    //预估当前车牌 所在页面
                    noPage = (sufMin > sufCurrent) ? ((sufMin - sufCurrent) / 40 + 2) : 1;
                    if (noPage > 1)
                    {
                        urlCodePage = Commons.UrlDbCodePage(UrlDb, prefCurrent, noPage);
                        htmlDocument = GetHtmlDocument(urlCodePage);
                        carsNodes = GetCarsHtmlNodes(htmlDocument);
                    }
                    if (carsNodes.Length != 0)
                    {
                        sufMin = CarHandler.ExtractNumberFromCarSuf(carsNodes[0].InnerText);
                        sufMax = CarHandler.ExtractNumberFromCarSuf(carsNodes[^0].InnerText);
                    }
                    else
                    {
                        while (true)
                        {
                            noPage -= 1;
                            urlCodePage = Commons.UrlDbCodePage(UrlDb, prefCurrent, noPage);
                            htmlDocument = GetHtmlDocument(urlCodePage);
                            carsNodes = GetCarsHtmlNodes(htmlDocument);
                            if (carsNodes.Length != 0)
                            {
                                sufMin = CarHandler.ExtractNumberFromCarSuf(carsNodes[0].InnerText);
                                sufMax = CarHandler.ExtractNumberFromCarSuf(carsNodes[^0].InnerText);
                                break;
                            }
                        }
                    }
                    //在预估页面中
                    if (sufMax >= sufCurrent && sufCurrent >= sufMin)
                    {
                        int index = IndexOfCarsNodes(sufCurrent, carsNodes);
                        if (index == 0)
                        {
                            return ScrapeStatusEnum.Db_not_found;
                        }
                        javdb = 
                    }
                }
            }



            throw new NotImplementedException();
        }

        private static int IndexOfCarsNodes(int sufCurrent, HtmlNode[] carsNodes)
        {
            for (int i = 0; i < carsNodes.Length; i++)
            {
                if (CarHandler.ExtractNumberFromCarSuf(carsNodes[i].InnerText) == sufCurrent)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public static HtmlNode[] GetCarsHtmlNodes(HtmlDocument prefPageHtmlDocument)
        {
            return prefPageHtmlDocument.DocumentNode.SelectNodes(Commons.DbCodePageCarsXpath).Nodes().ToArray();
        }
    }
}