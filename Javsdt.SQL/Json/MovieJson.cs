using Javsdt.Shared.Enum;
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
        public string CarOrigin { get; set; }
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
        // 8 剧评
        public string Review { get; set; }
        // 9 发行日期
        public string Release { get; set; }
        // 10 时长
        public string Runtime { get; set; }
        // 11 导演
        public string Director { get; set; }
        // 12 制造商
        public string Studio { get; set; }
        // 13 发行商
        public string Publisher { get; set; }
        // 14 评分
        public string Score { get; set; }
        // 15 封面Library
        public string CoverLibrary { get; set; }
        // 16 封面Bus
        public string CoverBus { get; set; }
        // 17 裁剪方式
        public CutType CutType { get; set; } = CutType.Unknown;
        // 18 db编号
        public string Javdb { get; set; }
        // 19 library编号
        public string Javlibrary { get; set; }
        // 20 Javbus编号
        public string Javbus { get; set; }
        // 21 arzon编号
        public string Arzon { get; set; }
        // 22 完成度，三大网站为全部
        public CompletionStatus Completion { get; set; } = CompletionStatus.Unknown;

        // 23 类型
        public List<string> Genres { get; set; }
        // 24 演员们
        public List<string> Actors { get; set; }

        // 25 版本
        public int Version { get; set; } = 0;

    }
}
