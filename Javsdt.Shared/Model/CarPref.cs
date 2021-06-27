using Javsdt.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model
{
    // 车牌前缀，1车牌前缀对多影片
    public class CarPref
    {
        [Key]
        public string Name { get; set; } = "ABC";
        
        // 状态
        public StatusType Type { get; set; } = StatusType.不知是否完结;
        // 当前数量
        public int Amount { get; set; }
        // 最大车牌
        public int MaxSuf { get; set; }
        // 最后日期
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateLast { get; set; }
        // 最后修改日期时间
        public DateTime TimeModify { get; set; }

        // 影片【集合导航】
        //public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
