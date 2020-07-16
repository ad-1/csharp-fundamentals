using System;
using System.Linq;

namespace Csvreader
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\WZFJCV\\Documents\\GitHub\\csharp-fundamentals\\csvreader\\data\\population.csv";
            var reader = new Csvreader(path);
            var countries = reader.GetCountries();
            Console.WriteLine("Countries from region: ");
            var region = Console.ReadLine();
            ShowCountriesFromRegion(countries, region);
        }

        private static void ShowCountriesFromRegion(Countries countries, string region)
        {
            var countriesFromRegion = countries.GetCountriesByContinent(region);
            foreach (var country in countriesFromRegion)
                Console.WriteLine($"{country.Name,-20} : {country.Population,20:N0}");
            Console.WriteLine($"Number of countries in {region}: {countriesFromRegion.Count}");
        }
    }
}
