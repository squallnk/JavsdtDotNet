using Javasdt.Shared.Enums;
using Javasdt.Shared.Models.SQL.Property;

namespace Javasdt.Shared.Models.SQL.Middle
{
    // 视频+演员，中间件，1视频对多，1演员对多
    public class MovieCast
    {
        // 组合主键
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = new Movie();

        public int CastId { get; set; }
        public Cast Cast { get; set; } = new Cast();

        public CastTypeEnum Type { get; set; }
    }
}