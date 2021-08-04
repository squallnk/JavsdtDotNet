using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.Scrape;
using System.Net;

namespace Javasdt.Collector.Handlers.Web
{
    interface IWebHandler
    {
        string GetHtml(string url);

        ScrapeStatusEnum Scrape(MovieFile movieFile, MovieModel movieModel);
    }
}
