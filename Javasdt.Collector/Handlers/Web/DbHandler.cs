using Javasdt.Shared.Models.SQL;
using System;
using HtmlAgilityPack;
using System.Net;
using Javasdt.Shared.Statics;
using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Scrape;
using System.Text.RegularExpressions;
using Javasdt.Shared.Exceptions;

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
                var webTitle = htmlDocument.DocumentNode.SelectSingleNode("//title").InnerText;
                if (webTitle.Contains(Commons.DbTitleNormalPart))
                {
                    return htmlDocument;
                }
                else if(webTitle.Contains(Commons.DbTitleNotFoundPart))
                {
                    throw new SpecifiedUrlException($"{Commons.DbSpecifiedErrorMsg}");
                }
            }
            throw new WebException();
        }

        public ScrapeStatusEnum Scrape(MovieFile movieFile, MovieModel movieModel)
        {
            string urlOnDb;
            string javdb;
            if (movieFile.Name.Contains(Commons.DbSpecifiedUrl))
            {
                Match match = Regex.Match(movieFile.Name, Commons.DbSpecifiedRegex);
                if (!match.Success)
                {
                    throw new SpecifiedUrlException($"{Commons.DbSpecifiedErrorMsg}");
                }
                javdb = match.Groups[1].Value;
                urlOnDb = $"{UrlDb}/v/{javdb}";
                HtmlDocument htmlDocument = GetHtml(urlOnDb);

                //        url_jav_db = f'{url_db}/v/{javdb}'
                //    html_jav_db = get_db_html(url_jav_db, proxy_db)
                //    if re.search(r'頁面未找到', html_jav_db):
                //        raise SpecifiedUrlError(f'你指定的javdb网址找不到jav: {url_jav_db}，')
                //else:
                //    # 指定的javlibrary网址有错误
                //    raise SpecifiedUrlError(f'你指定的javdb网址有错误: ')
            }
            throw new NotImplementedException();
        }
    }
}