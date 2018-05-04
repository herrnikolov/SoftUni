using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            var picturesCount = double.Parse(Console.ReadLine());
            var filterTime = double.Parse(Console.ReadLine());
            var filterFactor = double.Parse(Console.ReadLine());
            var uploadTime = double.Parse(Console.ReadLine());

            var percentage = filterFactor / 100.0;
            var usefulPictures = Math.Ceiling((picturesCount) * percentage);

            var secondsForFiltering = (picturesCount * filterTime);
            var secondsForUploading = (usefulPictures * uploadTime);

            var totalSeconds = (secondsForFiltering + secondsForUploading);

            var timeNeeded = TimeSpan.FromSeconds(totalSeconds).ToString(@"d\:hh\:mm\:ss");

            Console.WriteLine(timeNeeded);
        }
    }
}
