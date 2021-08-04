using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.SQL.Property;

namespace Javasdt.Shared.Models.SQL.Middle
{
    public class MovieCompany
    {
        // 组合主键
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = new Movie();

        public int CompanyId { get; set; }
        public Company Company { get; set; } = new Company();

        public CompanyTypeEnum Type { get; set; }
    }
}