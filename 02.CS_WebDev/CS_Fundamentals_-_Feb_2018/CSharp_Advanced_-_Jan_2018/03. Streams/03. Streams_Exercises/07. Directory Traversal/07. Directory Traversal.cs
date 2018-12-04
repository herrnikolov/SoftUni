using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._Directory_Traversal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Directory to be listed:");
            var directoryToList = Console.ReadLine();

            var allFiles = new Dictionary<string, List<FileInfo>>();

            var folder = Directory.GetFiles(directoryToList);

            foreach (var file in folder)
            {
                var currentFileInfo = new FileInfo(file);

                var extension = currentFileInfo.Extension;
                var size = currentFileInfo.Length;

                if (!allFiles.ContainsKey(extension))
                {
                    allFiles[extension] = new List<FileInfo>();
                }

                allFiles[extension].Add(currentFileInfo);
            }

            using (var writer = new StreamWriter("../report.txt"))
            {
                foreach (var file in allFiles
                    .OrderByDescending(f => f.Value.Count)
                    .ThenBy(f => f.Key))
                {
                    writer.WriteLine(file.Key);

                    foreach (var info in file.Value)
                    {
                        var fileName = info.Name;
                        var size = (double)info.Length / 1024;

                        writer.WriteLine($"--{fileName} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
