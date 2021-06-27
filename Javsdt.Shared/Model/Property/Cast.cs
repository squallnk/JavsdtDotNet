﻿using Javsdt.Shared.Enum;
using Javsdt.Shared.Model.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model.Property
{
    // 演员，多对多，1演员对多MovieActor
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "未知Cast";
        public string NameZh { get; set; } = "未知Cast";

        // 归属于PopularCast【引用导航】
        public PopularCast? PopularCast { get; set; }

        // 视频+演职人员【集合导航】
        public List<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}