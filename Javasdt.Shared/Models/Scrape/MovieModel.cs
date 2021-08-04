using Javasdt.Shared.Enums;
using System.Collections.Generic;

namespace Javasdt.Shared.Models.Scrape
{
    public class MovieModel
    {
        // 1 通用车牌
        public string Car { get; set; } = "ABC-123";
        // 2 原始车牌
        public string? CarOrigin { get; set; }
        // 3 系列
        public string? Series { get; set; }
        // 4 原标题
        public string? Title { get; set; }
        // 5 简体中文标题
        public string? TitleZh { get; set; }
        // 6 剧情概述
        public string? Plot { get; set; }
        // 7 简体剧情
        public string? PlotZh { get; set; }
        // 8 剧评
        public string? Review { get; set; }
        // 9 发行日期
        public string? Release { get; set; }
        // 10 时长
        public int Runtime { get; set; }
        // 11 导演
        public string? Director { get; set; }
        // 12 制造商
        public string? Studio { get; set; }
        // 13 发行商
        public string? Publisher { get; set; }
        // 14 评分
        public int Score { get; set; }
        // 15 封面Library
        public string? CoverLibrary { get; set; }
        // 16 封面Bus
        public string? CoverBus { get; set; }
        // 17 裁剪方式
        public CutTypeEnum CutType { get; set; } = CutTypeEnum.Unknown;
        // 18 db编号
        public string? Javdb { get; set; }
        // 19 library编号
        public string? Javlibrary { get; set; }
        // 20 Javbus编号
        public string? Javbus { get; set; }
        // 21 arzon编号
        public string? Arzon { get; set; }
        // 22 完成度，三大网站为全部
        public CompletionStatusEnum CompletionStatus { get; set; } = CompletionStatusEnum.Unknown;

        // 23 版本
        public int Version { get; set; } = 0;

        // 24 类型
        public List<string> Genres { get; set; } = new List<string>();
        // 25 演员们
        public List<string> Actors { get; set; } = new List<string>();
        //26 最后更新日期
        public System.DateTime TimeModify { get; set; } = System.DateTime.Now;


        public CompletionStatusEnum PrefectCompletionStatus()
        {
            if (string.IsNullOrEmpty(Javdb))
            {
                if (string.IsNullOrEmpty(Javlibrary))
                {
                    if (string.IsNullOrEmpty(Javbus))
                    {
                        return CompletionStatusEnum.DbLibraryBus;
                    }
                    else
                    {
                        return CompletionStatusEnum.DbLibrary;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Javbus))
                    {
                        return CompletionStatusEnum.DbBus;
                    }
                    else
                    {
                        return CompletionStatusEnum.OnlyDb;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Javlibrary))
                {
                    if (string.IsNullOrEmpty(Javbus))
                    {
                        return CompletionStatusEnum.LibraryBus;
                    }
                    else
                    {
                        return CompletionStatusEnum.OnlyLibrary;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Javbus))
                    {
                        return CompletionStatusEnum.OnlyBus;
                    }
                    else
                    {
                        return CompletionStatusEnum.Unknown;
                    }
                }
            }
        }
    }
}
