using Javsdt.Shared.Model.SQL.Property;

namespace Javsdt.Shared.Model.SQL.Middle
{
    // 视频+特征，中间件，1视频对多，1特征对多
    public class MovieGenre
    {
        // 组合主键
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = new Movie();

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = new Genre();
    }
}