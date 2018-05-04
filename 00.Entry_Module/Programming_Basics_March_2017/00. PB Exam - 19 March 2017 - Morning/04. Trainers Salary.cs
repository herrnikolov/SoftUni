using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Trainers_Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/499#0

            var lections = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double ratePerLection = budget / lections;

            int hoursJelev = 0;
            int hoursRoYaL= 0;
            int hoursRoli = 0;
            int hoursTrofon = 0;
            int hoursSino = 0;
            int hoursOthers = 0;

            for (int i = 1; i <= lections; i++)
            {
                string lecturer = Console.ReadLine();
                if (lecturer == "Jelev") hoursJelev++;
                if (lecturer == "RoYaL") hoursRoYaL++;
                if (lecturer == "Roli") hoursRoli++;
                if (lecturer == "Trofon") hoursTrofon++;
                if (lecturer == "Sino") hoursSino++;
                if (lecturer != "Jelev" && lecturer != "RoYaL" && lecturer != "Roli" && lecturer != "Trofon" && lecturer != "Sino") hoursOthers++;
            }

            Console.WriteLine("Jelev salary: {0:f2} lv", hoursJelev * ratePerLection);
            Console.WriteLine("RoYaL salary: {0:f2} lv", hoursRoYaL * ratePerLection);
            Console.WriteLine("Roli salary: {0:f2} lv", hoursRoli * ratePerLection);
            Console.WriteLine("Trofon salary: {0:f2} lv", hoursTrofon * ratePerLection);
            Console.WriteLine("Sino salary: {0:f2} lv", hoursSino * ratePerLection);
            Console.WriteLine("Others salary: {0:f2} lv", hoursOthers * ratePerLection);
        }
    }
}
