using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Javsdt.Shared.Model.Property
{
    // 系列，1系列对多影片
    public class Series
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "未知Series";

        public string NameZh { get; set; } = "未知Series";

        // 影片【集合导航】
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
