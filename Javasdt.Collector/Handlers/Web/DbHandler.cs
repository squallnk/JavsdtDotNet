using Javasdt.Shared.Models.SQL;
using System;
using HtmlAgilityPack;
using System.Net;
using Javasdt.Shared.Statics;
using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Scrape;

namespace Javasdt.Collector.Handlers.Web
{
    public class DbHandler : IWebHandler
    {
        private readonly string UrlDb;
        private readonly WebProxy Proxy;

        public DbHandler(string urlDb, WebProxy proxy)
        {
            UrlDb = urlDb;
            Proxy = proxy;
        }

        public string GetHtml(string url)
        {
            HtmlWeb web = new ();
            HtmlDocument content;
            for (int retry = 0; retry < 10; retry++)
            {
                content = web.Load(url, "GET", Proxy, null);
                var webTitle = content.DocumentNode.SelectSingleNode("//title").InnerText;
                if (webTitle.Contains(Commons.DbTitleNormalPart) || webTitle.Contains(Commons.DbTitleNotFoundPart))
                {
                    return content.Text;
                }
                else
                {
                    Console.WriteLine(Commons.RequestsErrorMsg);
                }
            }
            throw new WebException();
        }

        public ScrapeStatusEnum Scrape(MovieFile movieFile, MovieModel movieModel)
        {
            if (movieFile.Name.Contains(Commons.DbSpecifiedUrl))
            {

            }
            throw new NotImplementedException();
        }
    }
}