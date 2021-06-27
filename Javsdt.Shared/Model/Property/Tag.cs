using Javsdt.Shared.Model.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model.Property
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string NameZh { get; set; } = "未知Tag";

        // 视频+特征【集合导航】
        public List<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
    }
}