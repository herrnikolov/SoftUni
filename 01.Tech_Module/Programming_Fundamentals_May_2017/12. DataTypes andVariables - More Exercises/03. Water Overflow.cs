using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte pipesCount = byte.Parse(Console.ReadLine());
            byte tankCapacity = byte.MaxValue;
            byte currentTankVolume = 0;
            while (pipesCount > 0)
            {
                short waterVolume = short.Parse(Console.ReadLine());
                if (currentTankVolume + waterVolume <= tankCapacity)
                {
                    currentTankVolume += (byte)waterVolume;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                pipesCount--;
            }

            Console.WriteLine(currentTankVolume);
        }
    }
}