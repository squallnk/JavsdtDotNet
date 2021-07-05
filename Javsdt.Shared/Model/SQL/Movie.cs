using Javsdt.Shared.Enum;
using Javsdt.Shared.Model.SQL.Middle;
using Javsdt.Shared.Model.SQL.Property;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model.SQL
{
    // 一般电影
    public class Movie
    {
        [Key]
        // 0 Id
        public int Id { get; set; }
        // 1 车牌
        public string Car { get; set; } = "ABC-123";
        // 2 车牌
        public string? CarOrigin { get; set; }                  // +1
        // 3 车牌前缀
        public string CarPref { get; set; } = "ABC";            // +1
        // 4 车牌后缀
        public int CarSuf { get; set; }                         // +1
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Release { get; set; }

        // 14 封面Library
        public string? CoverLibrary { get; set; }
        // 15 封面Bus
        public string? CoverBus { get; set; }
        // 16 裁剪方式
        public CutType CutType { get; set; } = CutType.Unknown;

        // 17 db编号
        public string? Javdb { get; set; }
        // 18 library编号
        public string? Javlibrary { get; set; }
        // 19 bus编号
        public string? Javbus { get; set; }
        // 20 arzon编号
        public string? Arzon { get; set; }

        // 21 系列 【引用导航】
        public int SeriesId { get; set; }
        public Series? Series { get; set; }

        // 22 完成度，三大网站为全部
        public CompletionStatus Completion { get; set; } = CompletionStatus.Unknown;
        // 23 版本
        public int Version { get; set; } = 0;

        // 24 制造商 【集合导航】
        public List<MovieCompany> MovieCompanys { get; set; } = new List<MovieCompany>();
        // 24 演职人员 【集合导航】
        public List<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
        // 25特征 【集合导航】
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        // 26标签 【集合导航】
        public List<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
    }
}
