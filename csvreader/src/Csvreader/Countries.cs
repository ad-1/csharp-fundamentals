using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Csvreader
{
    class Countries: IEnumerable<Country>
    {

        readonly Dictionary<string, Country> countries;

        public int Count
        {
            get
            {
                return countries.Count;
            }
        }

        public Countries()
        {
            countries = new Dictionary<string, Country>();
        }

        public void AddCountries(List<Country> newCountries)
        {
            foreach(var newCountry in newCountries)
            {
                countries[newCountry.Code] = newCountry;
            }
        }

        public void AddCountry(Country country)
        {
            countries[country.Code] = country;
        }

        public Country GetCountryByCode(string code)
        {
            return countries[code];
        }

        public int CompareCountries(Country a, Country b)
        {
            return a.CompareTo(b);
        }

        public IEnumerator<Country> GetEnumerator()
        {
            foreach(var country in countries.Values)
            {
                yield return country;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
