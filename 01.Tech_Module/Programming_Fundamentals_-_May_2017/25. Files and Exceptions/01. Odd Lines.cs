using System;
using System.IO;
using System.Linq;
using System.Text;

class OddLines
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("everybody wants some.txt");
        var oddLines = lines.Where((line, index) => index % 2 != 0);
        File.WriteAllLines("odd lines ews.txt", oddLines);
    }

    static void NewWayToDoIt()
    {
        string[] lines = File.ReadAllLines("everybody wants some.txt");
        File.Delete("odd lines ews.txt");
        for (int cycle = 1; cycle < lines.Length; cycle += 2)
        {
            File.AppendAllText("new odd lines ews.txt", lines[cycle] + Environment.NewLine);
        }
    }

}
}