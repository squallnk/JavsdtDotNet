using Javasdt.Shared.Enums;
using System;

namespace Javasdt.Shared.DTO
{
    public class MovieRes
    {
        // 0 Id
        public int Id { get; set; }
        // 1 车牌
        public string Car { get; set; } = "ABC-123";
        // 2 车牌
        public string? CarOrigin { get; set; }
        // 5 原标题
        public string? Title { get; set; }
        // 6 简体中文标题
        public string? TitleZh { get; set; }
        // 7 剧情概述
        public string? Plot { get; set; }
        // 8 简体剧情
        public string? PlotZh { get; set; }
        // 9 简体剧情
        public string? Review { get; set; }
        // 10 评分 10倍
        public int Score { get; set; }
        // 11 时长
        public int Runtime { get; set; }
        // 12 发行年份
        public int Year { get; set; }
        // 13 发行日期
        public DateTime Release { get; set; }

        // 14 封面Library
        public string? CoverLibrary { get; set; }
        // 15 封面Bus
        public string? CoverBus { get; set; }
        // 16 裁剪方式
        public CutTypeEnum CutType { get; set; } = CutTypeEnum.Left;

        // 17 db编号
        public string? Javdb { get; set; }
        // 18 library编号
        public string? Javlibrary { get; set; }
        // 19 bus编号
        public string? Javbus { get; set; }
        // 20 arzon编号
        public string? Arzon { get; set; }

        // 21 系列
        public string? Series { get; set; }

        // 22 完成度，三大网站为全部
        public CompletionStatusEnum CompletionStatus { get; set; } = CompletionStatusEnum.Unknown;
        // 23 版本
        public int Version { get; set; }

        // 24 制造商 【集合导航】
        public CompanyPreview[]? Companys { get; set; }
        // 24 演职人员 【集合导航】
        public CastPreview[]? Casts { get; set; }
        // 25特征 【集合导航】
        public string[]? Genres { get; set; }
        // 26标签 【集合导航】
        public string[]? Tags { get; set; }
    }
}
