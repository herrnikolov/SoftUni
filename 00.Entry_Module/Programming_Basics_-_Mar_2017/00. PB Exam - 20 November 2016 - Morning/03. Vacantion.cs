using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 20 November 2016 - Morning
            //https://judge.softuni.bg/Contests/Practice/Index/354#2


            var adults = int.Parse(Console.ReadLine());
            var stuents = int.Parse(Console.ReadLine());
            var nights = int.Parse(Console.ReadLine());
            var transportation = Console.ReadLine();

            var adultTransportationCost = 0.0;
            var studentTransportationCost = 0.0;

            switch (transportation.ToLower())
            {
                case ("train"):
                    if (adults + stuents >= 50)
                    {
                        adultTransportationCost = (adults * 24.99) * 0.5;
                        studentTransportationCost = (stuents * 14.99) * 0.5;
                    }
                    else
                    {
                        adultTransportationCost = adults * 24.99;
                        studentTransportationCost = stuents * 14.99;
                    }
                    break;
                case ("bus"):
                    adultTransportationCost = adults * 32.50;
                    studentTransportationCost = stuents * 28.50;
                    break;
                case ("boat"):
                    adultTransportationCost = adults * 42.99;
                    studentTransportationCost = stuents * 39.99;
                    break;
                case ("airplane"):
                    adultTransportationCost = adults * 70.00;
                    studentTransportationCost = stuents * 50.00;
                    break;

                default:
                    break;
            }

            var totalTransportationCost = (adultTransportationCost + studentTransportationCost) * 2;
            var accommodation = nights * 82.99;
            var travelAgencyFee = (totalTransportationCost + accommodation) * 0.1;
            var totalCosts = totalTransportationCost + accommodation + travelAgencyFee;
            Console.WriteLine("{0:f2}", totalCosts);



        }
    }
}
