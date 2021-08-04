using Javasdt.Shared.Models.SQL.Property;

namespace Javasdt.Shared.Models.SQL.Middle
{
    // 视频+标签，中间件，1视频对多，1标签对多
    public class MovieTag
    {
        // 组合主键
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = new Movie();

        public int TagId { get; set; }
        public Tag Tag { get; set; } = new Tag();

    }
}