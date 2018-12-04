using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string var1 = Console.ReadLine();
            bool var2 = Convert.ToBoolean(var1);
            //if (var2 == true)
            //{
            //    Console.WriteLine("Yes");
            //}
            //else if (var2 == false)
            //{
            //    Console.WriteLine("No");
            //}
            var isCoverted = var2 ? "Yes" : "No";
            Console.WriteLine(isCoverted);
            
        }
    }
}
