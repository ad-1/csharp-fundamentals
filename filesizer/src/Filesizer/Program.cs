using System;
using System.IO;

namespace Filesizer
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@".");
            FileInfo[] files = d.GetFiles("*.cs");
            Console.WriteLine("Number of files in directory: " + files.Length);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
