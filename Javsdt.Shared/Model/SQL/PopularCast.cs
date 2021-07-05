using Javsdt.Shared.Model.SQL.Property;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Javsdt.Shared.Model.SQL
{
    public class PopularCast
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "未知PopularCast";

        // 包含的演员【集合导航】
        public List<Cast> Casts { get; set; } = new List<Cast>();


    }
}
