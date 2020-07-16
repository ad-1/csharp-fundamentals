using System;
using System.Collections.Generic;
using System.Linq;

namespace Csvreader
{
    class Countries
    {

        readonly Dictionary<string, Country> countryRegister;
        readonly Dictionary<string, List<Country>> continentRegister;

        public int Count
        {
            get
            {
                return countryRegister.Count;
            }
        }

        public Countries()
        {
            countryRegister = new Dictionary<string, Country>();
            continentRegister = new Dictionary<string, List<Country>>();
        }

        public void AddCountries(List<Country> newCountries)
        {
            foreach (var newCountry in newCountries)
            {
                AddCountry(newCountry);
            }
        }

        public void AddCountry(Country newCountry)
        {
            countryRegister[newCountry.Code] = newCountry;
            AddToContinentRegister(newCountry);
        }

        private void AddToContinentRegister(Country newCountry)
        {
            var continent = newCountry.Continent;
            if (continentRegister.ContainsKey(continent))
            {
                continentRegister[continent].Add(newCountry);
            }
            else
            {
                continentRegister[continent] = new List<Country> { newCountry };
            }
        }

        public List<Country> GetCountriesByContinent(string continent)
        {
            var countries = new List<Country>();
            continentRegister.TryGetValue(continent, out countries);
            return countries;
        }

        public IEnumerable<Country> GetFirstNCountries(int n)
        {
            return countryRegister.Values.Take(n);
        }

        public IEnumerable<Country> GetNCountriesAlphabetically(int n)
        {
            return countryRegister.Values.OrderBy(c => c.Name).Take(n);
        }

        public void RemoveCountriesWithComma()
        {
            Console.WriteLine($"Removing countries with comma.. Count before = {Count}");
            foreach (var country in countryRegister.Values)
            {
                if (country.Name.Contains(","))
                {
                    countryRegister.Remove(country.Code);
                }
            }
            Console.WriteLine($"Count after = {Count}");
        }

        public Country GetCountryByCode(string code)
        {
            return countryRegister[code];
        }

        public int CompareCountries(Country a, Country b)
        {
            return a.CompareTo(b);
        }

    }
}
