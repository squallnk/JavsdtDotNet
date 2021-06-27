using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Javsdt.Shared
{
    public class EnvSettings
    {
        public static string CurrentDirectory = Environment.CurrentDirectory;

        //Web Api用下面
        //public static string ProjectDirectory = Path.GetFullPath(@"..\");
        //SQL项目用下面
        public static string? ProjectDirectory = Directory.GetParent(CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;
        //示例
        //public static string ProjectDirectory = @"D:\MyGit\MyProjects\JavsdtDotNet";

        public static string JsonsDirectory = @"D:\MyData\收集的json";
        public static string NewJsonsDirectory = @$"{JsonsDirectory}\第6批json";
        public static string TestJsonsDirectory = @$"{JsonsDirectory}\单独测试";
        public static string ErrorJsonsPath = @$"{JsonsDirectory}\错误的json";
    }
}
