
using System;

namespace Javasdt.Shared.Statics
{
    public class Commons
    {
        #region 
        public const string RequestsErrorMsg = "    >打开网页失败，重新尝试...";

        public const string DbTitleNormalPart = "成人影片數據庫";

        public const string DbTitleNotFoundPart = "頁面未找到";
        #endregion

        public const string DbSpecifiedUrl = "仓库";

        public const string DbSpecifiedRegex = @"仓库(\w+?)\.";

        public const string DbSpecifiedErrorMsg = "你指定的javdb网址找不到jav: ";

        public static string NetworkErrorMsg(string url) => $">>请检查你的网络环境是否可以打开: {url}";

        public const string DbCodePageCarsXpath = "//*[@id=\"videos\"]/div/div[*]/a/div[2]/text()";

        public static string UrlDbCodePage(string UrlDb, string prefCurrent, int noPage) => $"{UrlDb}/video_codes/{prefCurrent}?page={noPage}";
    }
}
