using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam___Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            var area = double.Parse(Console.ReadLine());
            var kgGrape = double.Parse(Console.ReadLine());
            var litresToCheck = double.Parse(Console.ReadLine());
            var workers = double.Parse(Console.ReadLine());

            var grapeTotal = area * kgGrape;
            var wineLitres = 0.4 * grapeTotal / 2.5;

            if (wineLitres >= litresToCheck)
            {
                double rest = wineLitres - litresToCheck;
                double wintePerPerson = rest / workers;

                Console.WriteLine("Good harves this year! Total wine: {0} litres.", Math.Floor(wineLitres));
                Console.WriteLine("{0} litres left -> {1} litres per person.", Math.Ceiling(rest), Math.Ceiling(wintePerPerson));
            }
            else
            {
                double rest = litresToCheck - wineLitres;
                Console.WriteLine("It will be a tough winter! More {0} litres wine needed.", Math.Floor(rest));

            }
        }
    }
}
