using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {

            var startingMoney = double.Parse(Console.ReadLine());
            var money = startingMoney;

            var line = Console.ReadLine();

            while (line != "Game Time")
            {
                double gamePrice;
                var gameTitle = string.Empty;

                switch (line)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        gameTitle = "OutFall 4";
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        gameTitle = "CS: OG";
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        gameTitle = "Zplinter Zell";
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        gameTitle = "Honored 2";
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        gameTitle = "RoverWatch";
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        gameTitle = "RoverWatch Origins Edition";
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        line= Console.ReadLine();
                        continue;
                }
                if (gamePrice > money)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {                    
                    money -= gamePrice;
                    Console.WriteLine($"Bought {gameTitle}");
                }
                if (money == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                line = Console.ReadLine();
                
            }
            var remainingMoney = startingMoney - money;

            Console.WriteLine($"Total spent: ${(remainingMoney):F2}. Remaining: ${money:F2}");
        }
    }
}
