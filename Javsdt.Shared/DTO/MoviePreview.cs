using Javsdt.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Javsdt.Shared.DTO
{
    public class MoviePreview
    {
        // 0 原始车牌
        public int Id { get; set; }
        // 1 车牌
        public string? Car { get; set; }
        // 2 原车牌
        public string? CarOrigin { get; set; }
        // 3 原标题
        public string? Title { get; set; }
        // 4 剧情概述
        public string? Plot { get; set; }
        // 5 评分 10倍
        public int Score { get; set; }
        // 6 时长
        public int Runtime { get; set; }
        // 7 发行年份
        public int Year { get; set; }
        // 8 发行日期
        public DateTime Release { get; set; }

        // 9 封面
        public string? FanartBase64 { get; set; }
        // 10 海报
        public CutType PosterCutType { get; set; } = CutType.Left;

        // 11 library编号
        public string? LibraryId { get; set; }
        // 12 bus编号
        public string? BusId { get; set; }
        // 13 db编号
        public string? DbId { get; set; }
        // 14 arzon编号
        public string? ArzonId { get; set; }

        // 15 最后修改日期时间
        public DateTime TimeModify { get; set; }


        // 16 系列
        public string? Series { get; set; }
    }
}
