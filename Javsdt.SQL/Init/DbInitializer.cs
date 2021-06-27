using Javsdt.Shared;
using Javsdt.SQL.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Javsdt.SQL.Init
{
    public class DbInitializer
    {
        public static void Initialize(JavsdtContext context)
        {
            context.Database.EnsureCreated();

            // 如果有数据了，就不初始化数据库种子
            if (context.Movies.Any())
            {
                return;
            }
            //WriteWorker.WriteJsonToDb(EnvSettings.NewJsonsDirectory);
            WriteWorker.WriteJsonToDb(EnvSettings.TestJsonsDirectory);
        }
    }
}
