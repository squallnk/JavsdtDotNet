using HtmlAgilityPack;
using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Scrape;
using System.Net;

namespace Javasdt.Scrape.Handlers.Web
{
    interface IWebHandler
    {
        HtmlDocument GetHtmlDocument(string url);

        ScrapeStatusEnum Scrape(MovieFile movieFile, MovieModel movieModel);
    }
}
