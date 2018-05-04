using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var centuries = int.Parse(Console.ReadLine());

            var years = centuries * 100;
            var days = (int)(years * 365.2422);
            var hours = days * 24;
            var minutes = hours * 60M;
            var seconds = minutes * 60M;
            var milliSeconds = seconds * 1000M;
            var microSeconds = milliSeconds * 1000;
            var nanoSeconds = microSeconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes" +
                        $" = {seconds} seconds = {milliSeconds} milliseconds = {microSeconds} microseconds = {nanoSeconds} nanoseconds");

        }
    }
}