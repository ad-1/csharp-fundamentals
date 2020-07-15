using System;

namespace Csvreader
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\WZFJCV\\Documents\\GitHub\\csharp-fundamentals\\csvreader\\data\\population.csv";
            var reader = new Csvreader(path);
            var countries = reader.GetAllCountries();
            foreach (var country in countries)
                Console.WriteLine($"{country.Name, -20} : {country.Population, 14:N0}");
            Console.WriteLine("Comparing countries: CHN and IND:");
            var a = new Country("andyland", "XDL", "Europe", 100000);
            var b = new Country("andyland", "BDL", "Europe", 100000);
            Console.WriteLine(countries.CompareCountries(a, b));
        }
    }
}
