using Javasdt.Scrape.Handlers.Web;
using Javasdt.Shared.Models.SQL;
using System;

namespace Javasdt.Scrape
{
    public class Handler
    {
        public void main(string car)
        {
            #region 从db收集
            //Movie movie = DbHandler.Collect(car);
            #endregion

            #region 从library收集
            //LibraryHandler.Collect(movie);
            #endregion

            #region 从bus收集
            //BusHandler.Collect(movie);
            #endregion

            #region 写数据库
            #endregion
        }
    }
}
