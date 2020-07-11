using System;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            SelectBook();
        }

        private static void SelectBook()
        {
            while (true)
            {
                Console.WriteLine("Do you to store grades in memory (0) or on disk (1)?");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        CreateMemoryBook();
                        break;
                    case "1":
                        CreateDiskBook();
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Press q to quit");
                        break;
                }
            }
        }

        private static void CreateMemoryBook()
        {
            InmemoryBook book = new InmemoryBook("MemoryBook");
            book.GradeAdded += OnGradeAdded;
            while (true)
            {
                Console.Write("Please enter a grade, or press q to proceed: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    book.StoreGrade(float.Parse(input));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            book.PrintGrades();
            ShowStatistics(book);
        }
        
        private static void CreateDiskBook()
        {
            DiskBook book = new DiskBook("DiskBook");
            while (true)
            {
                Console.Write("Please enter a grade, or press q to proceed: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    book.StoreGrade(float.Parse(input));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            ShowStatistics(book);
        }

        static void ShowStatistics(Book book)
        {
            Statistics stats = book.GetStatistics();
            Console.WriteLine($"Average grade: {stats.Average:N2}");
            Console.WriteLine($"Highest grade: {stats.High:N2}");
            Console.WriteLine($"Lowest grade: {stats.Low:N2}");
            System.Console.WriteLine($"Average letter grade: {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade was added");
        }

    }

}
