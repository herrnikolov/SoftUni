//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _05.Array_Manipulator
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var list = Console.ReadLine()
//                .Split()
//                .Select(int.Parse)
//                .ToList();

//            var line = Console.ReadLine();
//            while (line != "print")
//            {
//                var tokens = line.Split();
//                var command = tokens[0];
//                if (command == "add")
//                {
//                    var index = int.Parse(tokens[1]);
//                    var element = int.Parse(tokens[2]);

//                    list.Insert(index, element);
//                }
//                else if (command == "addMany")
//                {
//                    var index = int.Parse(tokens[1]);
//                    var element = new List<int>();
//                    for (int i = 2; i < tokens.Length; i++)
//                    {
//                        var currentItem = int.Parse(tokens[i]);
//                        element.Add(currentItem);
//                    }
//                    list.InsertRange(index, element);
//                }
//                else if (command == "contains")
//                {
//                    var element = int.Parse(tokens[1]);
//                    var index = list.IndexOf(element);

//                    Console.WriteLine(index);
//                    //var index = -1;
//                    //if (list.Contains(element))
//                    //{
//                    //    for (int i = 0; i < list.Count; i++)
//                    //    {
//                    //        if (list[i] == element)
//                    //        {
//                    //            index = i;
//                    //            break;
//                    //        }
//                    //    }
//                    //}
//                }
//                else if (command == "remove")
//                {
//                    var index = int.Parse(tokens[1]);
//                    list.RemoveAt(index);
//                }
//                else if (command == "shift")
//                {
//                    var count = int.Parse(tokens[1]) % list.Count;
//                    for (int i = 0; i < count; i++)
//                    {
//                        list.Add(list[0]);
//                        list.RemoveAt(0);
//                    }
//                }
//                else if (command == "sumPairs")
//                {
//                    var pairSum = new List<int>();

//                    for (int i = 0; i < list.Count - 1; i += 2)
//                    {
//                        var currentElement = list[i];
//                        var nextElement = 0;
//                        if (i < list.Count -1)
//                        {
//                            nextElement = list[i + 1];
//                        }                                              
//                        var elementSum = currentElement + nextElement;
//                        pairSum.Add(elementSum);
//                    }
//                    list = pairSum;
//                }
//                line = Console.ReadLine();
//            }
//            Console.WriteLine("[" + string.Join(", ", list)+ "]");

//        }
//    }
//}




using System;
using System.Collections.Generic;
using System.Linq;

public class Array_Manipulator
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var line = Console.ReadLine();

        while (!line.Equals("print"))
        {
            var command = line.Split();

            switch (command[0])
            {
                case "add":
                    numbers = AddsElementsAtSpecifiedIndex(numbers, command);
                    break;

                case "addMany":
                    numbers = AddsASetOfElementsAtSpecifiedIndex(numbers, command);
                    break;

                case "contains":
                    PrintWhetherListContainsNumber(numbers, command);
                    break;

                case "remove":
                    numbers = RemovesTheElementAtSpecifiedIndex(numbers, command);
                    break;

                case "shift":
                    numbers = ShiftElementsInList(numbers, command);
                    break;

                case "sumPairs":
                    numbers = SumElementsByPairs(numbers);
                    break;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine("[" + string.Join(", ", numbers) + "]");
    }

    private static List<int> SumElementsByPairs(List<int> numbers)
    {
        var pairsSums = new List<int>();

        for (int i = 0; i < numbers.Count; i += 2)
        {
            if (numbers.Count > i + 1)
            {
                pairsSums.Add(numbers[i] + numbers[i + 1]);
            }

            else
            {
                pairsSums.Add(numbers[i]);
            }
        }

        numbers = pairsSums;

        return numbers;
    }

    private static List<int> AddsASetOfElementsAtSpecifiedIndex(List<int> numbers, string[] command)
    {
        var index = int.Parse(command[1]);
        var elements = new int[command.Length - 2];

        for (int i = 2; i < command.Length; i++)
        {
            var currentElement = int.Parse(command[i]);

            elements[i - 2] = currentElement;
        }

        numbers.InsertRange(index, elements);

        return numbers;
    }

    private static List<int> ShiftElementsInList(List<int> numbers, string[] command)
    {
        var rotations = int.Parse(command[1]) % numbers.Count();

        return numbers
                .Skip(rotations)
                .Concat(numbers.Take(rotations))
                .ToList();
    }

    private static List<int> RemovesTheElementAtSpecifiedIndex(List<int> numbers, string[] command)
    {
        var index = int.Parse(command[1]);

        numbers.RemoveAt(index);

        return numbers;
    }

    private static void PrintWhetherListContainsNumber(List<int> numbers, string[] command)
    {
        var element = int.Parse(command[1]);

        var index = numbers.IndexOf(element);

        Console.WriteLine(index);
    }

    private static List<int> AddsElementsAtSpecifiedIndex(List<int> numbers, string[] command)
    {
        var index = int.Parse(command[1]);
        var element = int.Parse(command[2]);

        numbers.Insert(index, element);

        return numbers;
    }
}
