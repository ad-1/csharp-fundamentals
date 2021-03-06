﻿using System;
using System.IO;

namespace Csvreader
{
    class Csvreader
    {

        private readonly string Path;

        public Csvreader(string path)
        {
            this.Path = path;
        }

        public Countries GetCountries()
        {
            using var reader = new StreamReader(Path);
            reader.ReadLine();
            var countries = new Countries();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var country = ParseCountryFromCSVData(line);
                countries.AddCountry(country);
            }
            return countries;
        }

        private Country ParseCountryFromCSVData(string line)
        {
            var data = line.Split(',');
            var dataLength = data.Length;
            string name, code, continent;
            double population;
            if (dataLength == 5)
            {
                name = data[0] + ", " + data[1];
                code = data[2];
                continent = data[3];
                population = double.TryParse(data[4], out population) ? population : 0;
            }
            else
            {
                name = data[0];
                code = data[1];
                continent = data[2];
                population = double.TryParse(data[3], out population) ? population : 0;
            }
            return new Country(name, code, continent, population);
        }

    }
}
