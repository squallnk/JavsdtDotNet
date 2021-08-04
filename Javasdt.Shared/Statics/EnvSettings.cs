using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Javasdt.Shared.Statics
{
    public class EnvSettings
    {
        public static readonly string CurrentDirectory = Environment.CurrentDirectory;

        //（1）Web Api用下面
        public static readonly string ProjectDirectory = Path.GetFullPath(@"..\");

        //（2）SQL项目用下面
        //public static readonly string? ProjectDirectory = Directory.GetParent(CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;

        //（3）固定值
        //public static readonly string ProjectDirectory = @"D:\MyGit\MyProjects\JavasdtDotNet";

        public static readonly string JsonsDirectory = @"D:\MyData\AlreadyJsons";
        public static readonly string NewJsonsDirectory = @$"{JsonsDirectory}\第6批json";
        public static readonly string TestJsonsDirectory = @$"{JsonsDirectory}\单独测试";
        public static readonly string ErrorJsonsPath = @$"{JsonsDirectory}\错误的json";
    }
}
