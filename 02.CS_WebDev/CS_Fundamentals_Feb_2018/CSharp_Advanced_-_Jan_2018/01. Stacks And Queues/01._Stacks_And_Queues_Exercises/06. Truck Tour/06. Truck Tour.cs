using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int counter = 0; counter < n; counter++)
            {
                var pump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    var currentPump = queue.Dequeue();
                    var pumpFuel = currentPump[0];
                    var nextPumpDistance = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
        
            }
        }
    }
}

//Alternative Solution with Tuple
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _06.TruckTour
//{
//    class TruckTour
//    {
//        static void Main()
//        {
//            int n = int.Parse(Console.ReadLine());

//            Queue<Tuple<int, int, int>> pumps = new Queue<Tuple<int, int, int>>();

//            for (int i = 0; i < n; i++)
//            {
//                var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//                int gas = numbers[0];
//                int distance = numbers[1];
//                int index = i;

//                pumps.Enqueue(new Tuple<int, int, int>(gas, distance, i));
//            }

//            bool found = false;

//            while (true)
//            {
//                long totalGas = 0;
//                Tuple<int, int, int> startPump = pumps.Dequeue();
//                int startIndex = startPump.Item3;
//                totalGas += startPump.Item1;
//                totalGas -= startPump.Item2;
//                pumps.Enqueue(startPump);

//                while (totalGas >= 0)
//                {
//                    startPump = pumps.Dequeue();
//                    totalGas += startPump.Item1;
//                    totalGas -= startPump.Item2;
//                    int currentIndex = startPump.Item3;

//                    if (currentIndex == startIndex)
//                    {
//                        if (totalGas >= 0)
//                        {
//                            Console.WriteLine(startIndex);
//                            return;
//                        }
//                        else
//                        {
//                            return;
//                        }
//                    }

//                    pumps.Enqueue(startPump);
//                }
//            }
//        }
//    }
//}