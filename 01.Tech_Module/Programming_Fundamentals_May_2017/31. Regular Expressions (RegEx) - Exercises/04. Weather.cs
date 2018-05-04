﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = 
                new Regex(@"(?<city>[A-Z]{2})(?<temp>\d+\.\d+)(?<weather>[a-zA-Z]+)\|");

            var cities = new Dictionary<string, WeatherInfo>();

            var line = Console.ReadLine();

            while (line != "end")
            {
                var weatherMatch = regex.Match(line);

                if (!weatherMatch.Success)
                {
                    line = Console.ReadLine();
                    continue;
                }

                var city = weatherMatch.Groups["city"].Value;
                var averageTemp = double.Parse(weatherMatch.Groups["temp"].Value);
                var weather = weatherMatch.Groups["weather"].Value;

                var watherInfo = new WeatherInfo
                {
                    AverageTemperature = averageTemp,
                    Weather = weather
                };
                
                cities[city] = watherInfo;

                line = Console.ReadLine();
            }

            var sortedCities = cities
                .OrderBy(a => a.Value.AverageTemperature)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var cityInfo in sortedCities)
            {
                var city = cityInfo.Key;
                var watherInfo = cityInfo.Value;

                Console.WriteLine($"{city} => {watherInfo.AverageTemperature:F2} => {watherInfo.Weather}");
            }

        }
        class WeatherInfo
        {
            public double AverageTemperature { get; set; }
            public string Weather { get; set; }
        }
    }
}
