using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert side A of the Rectangle");
            var a = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Insert side B ofthe Rectangle");
            var b = decimal.Parse(Console.ReadLine());

            // TODO: calculate the area and print it
            Console.WriteLine("The Rectangle Area is:");
            var c = a * b;
            Console.WriteLine(c);
        }
    }
}
