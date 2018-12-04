using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("../copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream("../copyMe-Copy.png", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    int readBytes;
                    while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
