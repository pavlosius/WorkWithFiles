using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class DirectoryExtention
    {
        public static long DeleteAllFilesInDirectory(DirectoryInfo directoryInfo)
        {
            long deletedFilesSize = 0;
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                TimeSpan expriedTimeFromLastAccess = DateTime.Now.Subtract(file.LastAccessTime);
                Console.Write(String.Format($"{file.Name, -50} {file.Length} байт Время с момента последнего доступа: {expriedTimeFromLastAccess.ToString(@"dd\.hh\:mm\:ss"),-10} "));
                DateTime timeThreshold = DateTime.Now.AddMinutes(-30);
                if (file.LastAccessTime < timeThreshold)
                {
                    Console.WriteLine("Удален");
                    file.Delete();
                    deletedFilesSize += file.Length;
                }
                else
                {
                    Console.WriteLine("Не требует удаления");
                }
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                deletedFilesSize += DeleteAllFilesInDirectory(directory);

            }
            return deletedFilesSize;
        }

        public static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                size += GetDirectorySize(directory);
            }
            return size;
        }
    }
}
