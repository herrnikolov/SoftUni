using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._1000_Days_After_Birth
{
    class Program
    {
        static void Main(string[] args)
        {
            //string dab = "dd-MM-yyyy";
            //string value = Console.ReadLine();
            //DateTime userBirthday = DateTime.ParseExact(value, dab, null);
            //Console.WriteLine(userBirthday.AddDays(999).ToString("dd-MM-yyyy"));
            
            DateTime bitrhday = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            DateTime answer = bitrhday.AddDays(999);
            Console.WriteLine("{0:dd-MM-yyyy}", answer);

        }
    }
}
