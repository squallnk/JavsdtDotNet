using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Javasdt.SQL.Json
{
    public class FileExplorer
    {
        // 功能：获取所给路径中下一级的子文件夹们
        // 参数：文件夹路径
        // 返回：List<string> 下一级的子文件夹名称
        public static List<string> GetSubDirectoriesNames(string path)
        {
            List<string> directories = new List<string>();
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] di = root.GetDirectories();
            for (int i = 0; i < di.Length; i++)
            {
                directories.Add(di[i].Name);
            }
            return directories;
        }

        // 功能：获取所给路径中下一级的子文件们
        // 参数：directoryPath当前处理的文件夹路径，files已获取的子文件们
        // 返回：files 下一级的子文件名称
        public static List<string> GetSubFilesNames(string directoryPath, string ext)
        {
            List<string> files = new List<string>();

            DirectoryInfo currentDirectoryInfo = new DirectoryInfo(directoryPath);
            // 当前一级文件夹内的子文件们
            FileInfo[] currentFileInfos = currentDirectoryInfo.GetFiles();
            foreach (FileInfo f in currentFileInfos)
            {
                //Console.WriteLine(f.Name);
                if (f.Name.EndsWith(ext))
                {
                    files.Add(f.FullName);
                }
            }
            return files;
        }

        // 功能：获取所给路径文件夹的所有子文件
        // 参数：directoryPath当前处理的文件夹路径，files已获取的子文件们
        // 返回：files 所有子文件完整路径
        public static List<string> GetAllSubFilesPaths(string directoryPath, List<string> files, string ext)
        {
            DirectoryInfo currentDirectoryInfo = new DirectoryInfo(directoryPath);

            // 当前一级文件夹内的子文件们
            FileInfo[] currentFileInfos = currentDirectoryInfo.GetFiles();
            foreach (FileInfo f in currentFileInfos)
            {
                if (f.Name.EndsWith(ext))
                {
                    files.Add(f.FullName);
                }
            }

            // 当前一级文件夹内的子文件夹们
            DirectoryInfo[] subDirectoryInfos = currentDirectoryInfo.GetDirectories();
            //递归
            foreach (DirectoryInfo d in subDirectoryInfos)
            {
                GetAllSubFilesPaths(d.FullName, files, ext);
            }
            return files;
        }

    }
}
