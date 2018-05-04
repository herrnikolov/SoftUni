using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Number_Wars
{
    class Program
    {
        const int MaxCounter = 1_000_000;
        static void Main(string[] args)
        {
            var firstPlayerCards = new Queue<string>(Console.ReadLine().Split());
            var secondPlayerCards = new Queue<string>(Console.ReadLine().Split());

            var turnCounter = 0;
            bool gameOver = false;
            while (turnCounter < MaxCounter && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && !gameOver)
            {
                turnCounter++;
                var firstCard = firstPlayerCards.Dequeue();
                var secondCard = secondPlayerCards.Dequeue();
                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstPlayerCards.Enqueue(firstCard);
                    firstPlayerCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }
                else
                {
                    var cardsHand = new List<string>{firstCard, secondCard};
                    while (!gameOver)
                    {
                        if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int counter = 0; counter < 3; counter++)
                            {
                                var firstHandCard = firstPlayerCards.Dequeue();
                                var secondHandCard = secondPlayerCards.Dequeue();
                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);
                                cardsHand.Add(firstHandCard);
                                cardsHand.Add(secondHandCard);
                            }
                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsHand, firstPlayerCards);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCardsToWinner(cardsHand, secondPlayerCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                            break;
                        }
                    }
                }
            }
            var result = "";
            if (firstPlayerCards.Count == secondPlayerCards.Count)
                result = "Draw";
            else if (firstPlayerCards.Count > secondPlayerCards.Count)
                result = "First player wins";
            else if (firstPlayerCards.Count < secondPlayerCards.Count)
                result = "Second player wins";
            Console.WriteLine($"{result} after {turnCounter} turns");
        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstPlayerCards)
        {
            foreach (var card in cardsHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
            {
               firstPlayerCards.Enqueue(card); 
            }
        }

        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
