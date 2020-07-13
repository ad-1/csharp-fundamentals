using System;
using System.IO;

namespace Filesizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchFileExtension = "*.cs";
            DirectoryInfo d = new DirectoryInfo(@".");
            FileInfo[] files = d.GetFiles(searchFileExtension);
            Console.WriteLine("Number of files in directory: " + files.Length);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
