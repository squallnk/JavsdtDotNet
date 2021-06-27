using Javsdt.Shared.Enum;
using Javsdt.SQL.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javsdt.SQL.Update
{
    public class Repair
    {
        public static void ChangeCastType0To3()
        {
            using JavsdtContext context = new JavsdtContext();
            foreach (var movieCast in context.MovieCasts)
            {
                if (movieCast.Type == CastType.Unknown)
                {
                    movieCast.Type = CastType.Actress;
                }
            }
            context.SaveChanges();
        }
    }
}
