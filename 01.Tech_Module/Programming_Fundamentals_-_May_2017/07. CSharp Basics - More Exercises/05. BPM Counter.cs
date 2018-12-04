using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BPM_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bpm = double.Parse(Console.ReadLine());
            var beats = double.Parse(Console.ReadLine());

            double bars = Math.Round(beats / 4.0, 1);

            double secondsPerBeat = 60 / bpm;
            double totoalSeconds = secondsPerBeat * beats;

            int minutes = (int)totoalSeconds / 60;
            int seconds = (int)totoalSeconds % 60;

            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
