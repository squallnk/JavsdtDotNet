using Javsdt.Shared.Enum;
using Javsdt.Shared.Model.SQL.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model.SQL.Property
{
    // 发行商，1发行商对多影片
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "未知Company";
        public string NameZh { get; set; } = "未知Company";


        // 影片【集合导航】
        public List<MovieCompany> MovieCompanys { get; set; } = new List<MovieCompany>();
    }
}