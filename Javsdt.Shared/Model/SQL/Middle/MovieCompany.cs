using Javsdt.Shared.Enum;
using Javsdt.Shared.Model.SQL.Property;

namespace Javsdt.Shared.Model.SQL.Middle
{
    public class MovieCompany
    {
        // 组合主键
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = new Movie();

        public int CompanyId { get; set; }
        public Company Company { get; set; } = new Company();

        public CompanyType Type { get; set; }
    }
}