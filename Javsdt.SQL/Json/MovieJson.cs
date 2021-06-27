using System;
using System.Collections.Generic;
using System.Text;

namespace Javsdt.SQL.Json
{
    public class MovieJson
    {
        // 1 通用车牌
        public string Car { get; set; }
        // 2 原始车牌
        public string CarOriginLibrary { get; set; }
        // 3 系列
        public string Series { get; set; }
        // 4 原标题
        public string Title { get; set; }
        // 5 简体中文标题
        public string TitleZh { get; set; }
        // 6 剧情概述
        public string Plot { get; set; }
        // 7 简体剧情
        public string PlotZh { get; set; }
        // 8 发行日期
        public string Release { get; set; }
        // 9 时长
        public string Runtime { get; set; }
        // 10 导演
        public string Director { get; set; }
        // 11 制造商
        public string Studio { get; set; }
        // 12 发行商
        public string Publisher { get; set; }
        // 13 评分
        public string Score { get; set; }
        // 14 类型
        public List<string> Genres { get; set; }
        // 15 演员们
        public List<string> Actors { get; set; }
        // 16 db编号
        public string Javdb { get; set; }
        // 17 library编号
        public string Javlibrary { get; set; }
        // 18 arzon编号
        public string Arzon { get; set; }
        // 19 封面
        public string CoverLibrary { get; set; }
        // 20 json最后修改时间
        public string TimeModify { get; set; }

    }
}
