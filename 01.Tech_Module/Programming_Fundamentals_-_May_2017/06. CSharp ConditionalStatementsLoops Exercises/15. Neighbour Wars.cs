using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var roundHouseKickDmg = int.Parse(Console.ReadLine());
            var thunderousFistDmb = int.Parse(Console.ReadLine());

            var peshoHealth = 100;
            var goshoHealth = 100;
            var roundNum = 1;
            var canContinue = true;


            while (canContinue)
            {
                if (roundNum % 2 != 0)
                {
                    CalculateDamageAndHealth(roundHouseKickDmg, ref goshoHealth, roundNum, ref canContinue, "Pesho", "Roundhouse kick", "Gosho");
                }
                else
                {
                    CalculateDamageAndHealth(thunderousFistDmb, ref peshoHealth, roundNum, ref canContinue, "Gosho", "Thunderous fist", "Pesho");
                }

                if (roundNum % 3 == 0)
                {
                    goshoHealth += 10;
                    peshoHealth += 10;
                }

                roundNum++;
            }
        }

        public static void CalculateDamageAndHealth(int skillDamage, ref int currentOpponentHealth, int roundNumber, ref bool canContinue, string name, string skill, string opponent)
        {
            var currentPlayerName = name;
            var currentPlayerSkill = skill;
            var currentOpponentName = opponent;

            currentOpponentHealth -= skillDamage;

            if (currentOpponentHealth <= 0)
            {
                Console.WriteLine($"{currentPlayerName} won in {roundNumber}th round.");
                canContinue = false;
            }
            else
            {
                Console.WriteLine($"{currentPlayerName} used {currentPlayerSkill} and reduced {currentOpponentName} to {currentOpponentHealth} health.");
            }

        }
    }
}
