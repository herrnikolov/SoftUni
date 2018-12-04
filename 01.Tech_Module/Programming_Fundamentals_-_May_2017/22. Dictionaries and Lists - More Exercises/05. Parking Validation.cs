using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Parking_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new Dictionary<string, string>();

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var registerData = Console.ReadLine()
                    .Split();

                var command = registerData[0];
                var username = registerData[1];

                if (command.Equals("register"))
                {
                    var licensePlateNumber = registerData[2];

                    if (parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[username]}");
                    }

                    else if (!IsLicencePlateValid(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                    }

                    else if (parking.ContainsValue(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                    }

                    else
                    {
                        parking[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }

                else
                {
                    if (!parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }

                    else
                    {
                        parking.Remove(username);
                        Console.WriteLine($"user {username} unregistered successfully");
                    }
                }
            }

            foreach (var registeredUser in parking)
            {
                var username = registeredUser.Key;
                var licensePlateNumber = registeredUser.Value;

                Console.WriteLine($"{username} => {licensePlateNumber}");
            }
        }

        private static bool IsLicencePlateValid(string licensePlateNumber)
        {
            var isLenghtValid = licensePlateNumber.Length.Equals(8);

            var isFirstAndLastTwoUpperCase = licensePlateNumber.Take(2).All(char.IsUpper)
                && licensePlateNumber.Reverse().Take(2).All(char.IsUpper);


            return isLenghtValid && isFirstAndLastTwoUpperCase;
        }
    }
}
