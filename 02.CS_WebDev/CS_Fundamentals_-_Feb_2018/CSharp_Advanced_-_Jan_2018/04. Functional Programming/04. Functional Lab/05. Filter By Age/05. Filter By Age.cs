using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>(peopleCount);
            for (int counter = 0; counter < peopleCount; counter++)
            {
                var nameAndAge = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                people.Add(nameAndAge[0], int.Parse(nameAndAge[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            var filter = CreateFilter(condition, age);
            var printer = CreatePrinter(format);

            PrintPeople(people, filter, printer);
            
        }

        private static void PrintPeople(Dictionary<string, int> people, 
            Func<KeyValuePair<string, int>, bool> filter, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (filter(person))
                    printer(person);
            }
        }

        static Func<KeyValuePair<string,int>, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
                return x => x.Value < age;
            else
                return x => x.Value >= age;
        }
        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);

                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
