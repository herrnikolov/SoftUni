using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Photo_Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            var number = int.Parse(Console.ReadLine());

            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());

            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            var size = int.Parse(Console.ReadLine());

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            //my variable
            var sizeHumanreadablemeasure = string.Empty;
            var sizeShort = 0.0;
            //image size
            if (size <1024)
            {
                sizeHumanreadablemeasure = "B";
                sizeShort = size;
            }
            else if (size >= 1024 && size <= 1000000)
            {
                sizeHumanreadablemeasure = "KB";
                sizeShort = size / 1000.0;
                //sizeShort = Math.Round(sizeShort, 1);
            }
            else if (size >=1000001 )
            {
                sizeHumanreadablemeasure = "MB";
                sizeShort = (size / 1000.0) / 1000.0;
                //sizeShort = Math.Round(sizeShort, 1);
            }

            //resolution
            var oriantation = string.Empty;

            if (height > width)
            {
                oriantation = "portrait";
            }
            else if (width > height)
            {
                oriantation = "landscape";
            }
            else if (height == width)
            {
                oriantation = "square";
            }

            //output
            Console.WriteLine($"Name: DSC_{number:D4}.jpg");
            Console.WriteLine($"Date Taken: {day:D2}/{month:D2}/{year:D4} {hours:D2}:{minutes:D2}");
            Console.WriteLine($"Size: {sizeShort}{sizeHumanreadablemeasure}");
            Console.WriteLine($"Resolution: {width}x{height} ({oriantation})");
        }
    }
}
