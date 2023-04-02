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
    internal static class DirectoryExtention
    {
        public static long DeleteAllFilesInDirectory(DirectoryInfo directoryInfo)
        {
            long deletedFilesCount = 0;
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                TimeSpan expriedTimeFromLastAccess = DateTime.Now.Subtract(file.LastAccessTime);
                Console.Write(String.Format($"{file.Name,-50} Время с момента последнего доступа: {expriedTimeFromLastAccess.ToString(@"dd\.hh\:mm\:ss"),-10} "));
                DateTime timeThreshold = DateTime.Now.AddMinutes(-30);
                if (file.LastAccessTime < timeThreshold)
                {
                    Console.WriteLine("Удален");
                    file.Delete();
                    deletedFilesCount++;
                }
                else
                {
                    Console.WriteLine("Не требует удаления");
                }
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                deletedFilesCount += DeleteAllFilesInDirectory(directory);
            }
            return deletedFilesCount;
        }




    }
}
