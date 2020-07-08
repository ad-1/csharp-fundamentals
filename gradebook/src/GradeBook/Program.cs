using System;

namespace GradeBook
{
    class Program
    {

        // MARK: - Init

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments passed");
                return;
            }
            CalculateGrades(args);
        }

        // MARK: - Handlers

        static void CalculateGrades(string[] args)
        {
            float[] grades = Array.ConvertAll(args, float.Parse);
            Book book = new Book("GradeBook", grades);
            book.StoreGrades(new float[] {32.23F, 43.23F, 82.5F, 33.8F});
            Statistics stats = book.GetStatistics();
            Console.WriteLine($"Average grade: {stats.average:N2}");
            Console.WriteLine($"Highest grade: {stats.high:N2}");
            Console.WriteLine($"Lowest grade: {stats.low:N2}");
        }

    }

}
