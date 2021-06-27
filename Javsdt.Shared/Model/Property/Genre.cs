using Javsdt.Shared.Model.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model.Property
{
    // 特征，多对多，1特征对多MovieGenre
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string NameZh { get; set; } = "未知Genre";


        // 视频+特征【集合导航】
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}