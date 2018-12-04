using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programming Basics Exam - 19 March 2017 - Evening
            //https://judge.softuni.bg/Contests/Practice/Index/501#3

            var months = int.Parse(Console.ReadLine());

            double electricityBill = 0;
            double waterBill = 0;
            double internetBill = 0;
            double otherBills = 0;

            for (int i = 0; i < months; i++)
            {
                double electricityMonthely = double.Parse(Console.ReadLine());


                electricityBill += electricityMonthely;
                waterBill += 20;
                internetBill += 15;
                

                double otherMonthely = (20 + 15 + electricityMonthely) * 1.2;
                otherBills += otherMonthely;
            }

            double totalBills = (electricityBill + waterBill + internetBill + otherBills) / months;


            Console.WriteLine("Electricity: {0:f2} lv", electricityBill);
            Console.WriteLine("Water: {0:f2} lv", waterBill);
            Console.WriteLine("Internet: {0:f2} lv", internetBill);
            Console.WriteLine("Other: {0:f2} lv", otherBills);
            Console.WriteLine("Average: {0:f2} lv", totalBills);

        }
    }
}
