using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            var userLogs = new SortedDictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                var userData = line
                    .Split("= ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var IPAddres = userData[1];
                var message = userData[3];
                var userName = userData[5];

                if (!userLogs.ContainsKey(userName))
                {
                    userLogs[userName] = new Dictionary<string, int>();
                }

                if (!userLogs[userName].ContainsKey(IPAddres))
                {
                    userLogs[userName][IPAddres] = 0;
                }

                userLogs[userName][IPAddres]++;

                line = Console.ReadLine();
            }


            foreach (var user in userLogs)
            {
                Console.WriteLine($"{user.Key}: ");

                var count = 0;

                foreach (var logs in user.Value)
                {
                    if (user.Value.Count - 1 == count)
                    {
                        Console.WriteLine($"{logs.Key} => {logs.Value}.");
                    }

                    else
                    {
                        Console.Write($"{logs.Key} => {logs.Value}, ");
                    }

                    count++;
                }
            }
        }
    }
}
