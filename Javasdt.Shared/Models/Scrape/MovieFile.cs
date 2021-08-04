using System.IO;

namespace Javasdt.Shared.Models.Scrape
{
    public class MovieFile
    {
        public MovieFile(string car, string carId, string fileRaw, string dirCurrent, int episode, string subtitle, int noCurrent)
        {
            Car = car;
            CarId = carId;
            Pref = car.Split("-")[0];
            Name = fileRaw;
            Ext = Path.GetExtension(fileRaw);
            Dir = dirCurrent;
            Episode = episode;
            Subtitle = subtitle;
            ExtSubtitle = Path.GetExtension(subtitle);
            No = noCurrent;
        }

        public string Car { get; set; }

        public string CarId { get; set; }

        public string Pref { get; set; }

        public string Name { get; set; }

        public string Ext { get; set; }

        public string Dir { get; set; }

        public int Episode { get; set; }

        public int SumAllEpisodes { get; set; }

        public string Subtitle { get; set; }

        public string ExtSubtitle { get; set; }

        public int No { get; set; }

        public bool IsSubtitle { get; set; }

        public bool IsDivulge { get; set; }

        #region 静态成员
        //是否在独立文件夹中，当前文件夹下的javfile共享这一属性
        public static bool IsInSeparateFolder { get; set; }
        #endregion

        #region 实例属性
        public string Cd => (SumAllEpisodes > 1) ? $"-cd{Episode}" : string.Empty;

        public string Folder => Path.GetFileName(Dir);

        public string FullPath => $"{Dir}/{Name}";

        public string NameNoExt => Path.GetFileNameWithoutExtension(Name);

        public string PathSubtitle => $"{Dir}/{Subtitle}";
        #endregion

    }
}
