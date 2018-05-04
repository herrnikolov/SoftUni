using System;

namespace _04._Hotel_Reservation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            {
                var holidayArgs = Console.ReadLine().Split();

                var price = PriceCalculator.CalculatePrice(holidayArgs);

                Console.WriteLine($"{price:f2}");
            }
        }
    }
}