﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08._Full_Directory_Traversal
{
    class Program
    {
        private static List<string> allFolders = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Directory to be listed:");
            var directoryToList = Console.ReadLine();

            GetFolders(directoryToList);

            var allFiles = new Dictionary<string, List<FileInfo>>();

            foreach (var folder in allFolders)
            {
                var allFilesInCurrentFolder = Directory.GetFiles(folder);

                foreach (var file in allFilesInCurrentFolder)
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
            }

            using (var writer = new StreamWriter("../report_10.txt"))
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

        private static void GetFolders(string directoryToList)
        {
            var foldersInCurrentFolder = Directory.GetDirectories(directoryToList);

            foreach (var folder in foldersInCurrentFolder)
            {
                GetFolders(folder);
            }

            allFolders.AddRange(foldersInCurrentFolder);
        }
    }
}

