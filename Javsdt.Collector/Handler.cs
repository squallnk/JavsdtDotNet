using Javsdt.Shared.Model.SQL;
using System;

namespace Javsdt.Collector
{
    public class Handler
    {
        public void test(string car)
        {
            #region 从db收集
            Movie movie = DbHandler.Collect(car);
            #endregion

            #region 从library收集
            LibraryHandler.Collect(movie);
            #endregion

            #region 从bus收集
            BusHandler.Collect(movie);
            #endregion

            #region 写数据库
            #endregion
        }
    }
}
