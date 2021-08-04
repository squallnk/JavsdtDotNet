using Javasdt.Shared;
using Javasdt.SQL.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Javasdt.SQL.Init
{
    public class DbInitializer
    {
        public static void Initialize(JavasdtContext context)
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
