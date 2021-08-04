using Javasdt.Shared;
using Javasdt.SQL.Init;
using System;

namespace Javasdt.SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(EnvSettings.CurrentDirectory);
            //Console.WriteLine(EnvSettings.ProjectDirectory);
            var context = new JavasdtContext();
            DbInitializer.Initialize(context);

            // 1 导入新jsons
            //WriteWorker.WriteJsonToDb(EnvSettings.NewJsonsDirectory);

            // 2 修改错误的CastType3
            //Update.Repair.ChangeCastType0To3();

            Console.WriteLine("数据库ok!");
        }
    }
}