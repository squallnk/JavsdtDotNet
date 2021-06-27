using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javsdt.Shared.DTO
{
    public class MovieDetail : MoviePreview
    {
        // 21 演职人员 【集合导航】
        public CastPreview[] Casts { get; set; }
        // 20 制造商 【集合导航】
        public CompanyPreview[] Companys { get; set; }
        // 22 特征 【集合导航】
        public string[] Genres { get; set; }
        // 23 标签 【集合导航】
        public string[] Tags { get; set; }
    }
}
