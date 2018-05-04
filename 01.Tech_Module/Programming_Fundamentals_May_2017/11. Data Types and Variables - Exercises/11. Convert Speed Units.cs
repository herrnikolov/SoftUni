using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float timeInSeconds = seconds + minutes * 60 + hours * 3600;
            float distanceInKm = (float)distanceInMeters / 1000;
            float distanceImMiles = (float)distanceInMeters / 1609;
            float timeInHours = timeInSeconds / 3600;


            float metersPerSecond = distanceInMeters / timeInSeconds;

            float kmPerHours = distanceInKm / timeInHours;

            float milesPerHour = distanceImMiles / timeInHours;

            Console.WriteLine(metersPerSecond);
            Console.WriteLine(kmPerHours);
            Console.WriteLine(milesPerHour);
        }
    }
}
