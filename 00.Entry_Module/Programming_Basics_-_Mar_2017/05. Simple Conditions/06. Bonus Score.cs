using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            var bonusPoints = 0.0;

            if (num <= 100)
            {
                bonusPoints = 5;
            }
            else if (num > 1000)
            {
                bonusPoints = 0.1 * num;
            }
            else if (num > 100)
            {
                bonusPoints = 0.2 * num;
            }

            if (num % 2 == 0)
            {
                bonusPoints += 1;
            }

            else if (num % 10 == 5)
            {
                bonusPoints += 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(bonusPoints + num);


            //var score = double.Parse(Console.ReadLine());
            //double bonusScore = 0;         

            //if (score <= 100)
            //{
            //    bonusScore += 5;
            //}
            //else if ((score > 100) && (score <= 1000))
            //{
            //    bonusScore += 0.2 * score;
            //}
            //else
            //{
            //    bonusScore += 0.1 * score;
            //}

            //if (score % 2 == 0)
            //{
            //    bonusScore += 1;
            //}

            //if (score % 10 == 5)
            //{
            //    bonusScore += 2;
            //}

            //double totalScore = bonusScore + score;
            //Console.WriteLine(bonusScore);
            //Console.WriteLine(totalScore);

        }
    }
}