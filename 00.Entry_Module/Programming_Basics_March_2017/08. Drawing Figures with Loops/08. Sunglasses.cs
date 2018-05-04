using System;

class Sunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char star = '*';
        char line = '|';
        char lens = '/';

        for (int i = 1; i <= n; i++)
        {
            if (i == 1 || i == n)
            {
                Console.Write(new String(star, n * 2) + new String(' ', n) + new String(star, n * 2));
            }
            if (i > 1 && i < n && i != (n + 1) / 2)
            {
                Console.Write(new String(star, 1) + new String(lens, (n * 2) - 2) + new String(star, 1)
                            + new String(' ', n) + new String(star, 1) + new String(lens, (n * 2) - 2)
                            + new String(star, 1));
            }
            if (i == (n + 1) / 2)
            {
                Console.Write(new String(star, 1) + new String(lens, (n * 2) - 2) + new String(star, 1)
                            + new String(line, n) + new String(star, 1) + new String(lens, (n * 2) - 2)
                            + new String(star, 1));
            }
            Console.WriteLine();
        }
    }
}

