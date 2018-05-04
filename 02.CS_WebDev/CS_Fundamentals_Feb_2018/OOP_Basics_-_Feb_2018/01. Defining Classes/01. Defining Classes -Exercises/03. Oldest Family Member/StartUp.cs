using System;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main(string[] args)
    {
        // Judge system verification:
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int numberOfLines = int.Parse(Console.ReadLine());

        Family family = new Family();

        for (int i = 0; i < numberOfLines; i++)
        {
            var currentPersonArgs = Console.ReadLine().Split();

            var person = new Person(currentPersonArgs[0], int.Parse(currentPersonArgs[1]));

            family.AddMember(person);
        }

        Console.WriteLine(family.GetOldestMember());
    }
}