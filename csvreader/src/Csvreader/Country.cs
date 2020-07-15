using System;

namespace Csvreader
{
    class Country: IComparable
    {

        public string Name { get; }
        public string Code { get; }
        public string Continent { get; }
        public double Population { get; }

        public Country(string name, string code, string continent, double population)
        {
            this.Name = name;
            this.Code = code;
            this.Continent = continent;
            this.Population = population;
        }

        public int CompareTo(object obj)
        {
            Country c = obj as Country;
            if (c == null)
                throw new ArgumentException("object is not a Country object.");
            return Code.CompareTo(c.Code);
        }
    }
}
