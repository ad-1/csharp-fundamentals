using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Filesizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Full path to search directory: ");
            var path = Console.ReadLine();
            var searchFileExtension = "*";
            GetLargestFiles(path, searchFileExtension);
            Console.WriteLine("*****");
            GetLargestFilesUsingLinq(path, searchFileExtension);
        }

        private static void GetLargestFilesUsingLinq(string path, string searchFileExtension)
        {
            var query = from file in new DirectoryInfo(@$"{path}").GetFiles()
                        orderby file.Length descending
                        select file;
            foreach(var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-30 } : {file.Length,10:N0}");
            }
        }

        private static void GetLargestFiles(string path, string searchFileExtension)
        {
            DirectoryInfo dir = new DirectoryInfo(@$"{path}");
            FileInfo[] files = dir.GetFiles(searchFileExtension);
            if (files.Length < 5)
            {
                Console.WriteLine("There are not enough files in this directory for analysis!");
                return;
            }
            Array.Sort(files, new FileInfoComparer());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name,-20 } : {files[i].Length,10:N0}");
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }


    }
}
