using Javasdt.Shared.Enums;
using Javasdt.SQL.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javasdt.SQL.Update
{
    public class Repair
    {
        public static void ChangeCastType0To3()
        {
            using JavasdtContext context = new JavasdtContext();
            foreach (var movieCast in context.MovieCasts)
            {
                if (movieCast.Type == CastTypeEnum.Unknown)
                {
                    movieCast.Type = CastTypeEnum.Actress;
                }
            }
            context.SaveChanges();
        }
    }
}
