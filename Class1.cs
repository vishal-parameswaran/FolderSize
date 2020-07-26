using System;
using System.Linq;
using System.IO;
namespace FolderSize
{
    public class Program
    {
        public static string DirectorySize(String DirectoryName)
        {            
            if (Directory.Exists(DirectoryName)){
            DirectoryInfo dInfo = new DirectoryInfo(DirectoryName);
            bool includeSubDir = true;
            long totalSize = dInfo.EnumerateFiles()
                         .Sum(file => file.Length);            
            if (includeSubDir)
            {                
                totalSize += dInfo.EnumerateDirectories()
                         .Sum(dir => long.Parse(DirectorySize(dir.FullName)));
            }
            return totalSize.ToString();}
            else
            {
                return "Error: Incorrect Folder Name";
            }
        }
    }
}