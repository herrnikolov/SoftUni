using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            var widgth = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            var resolution = ((widgth * height) / 1000000.0);


            Console.WriteLine("{0}x{1} => {2}MP", widgth, height, Math.Round(resolution,1));
        }
    }
}
