﻿namespace _07DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main()
        {
            var directory = Console.ReadLine();
            var extensions = new SortedDictionary<string, Dictionary<string, double>>();
            var directorySelected = new DirectoryInfo(directory);
            var whole = directorySelected.GetFiles();

            GetFileExtensions(extensions, whole);

            GroupAndWrite(extensions);

        }
        static void GroupAndWrite(SortedDictionary<string, Dictionary<string, double>> extensions)
        {
            var orderedExtension = extensions.OrderByDescending(p => p.Value.Count).ThenBy(ext => ext.Key);
            using (StreamWriter destination = new StreamWriter(@"text.txt"))
            {
                foreach (var item in orderedExtension)
                {
                    destination.WriteLine(item.Key);
                    var orderedDic = item.Value.OrderBy(f => f.Value);
                    foreach (var output in orderedDic)
                    {
                        destination.WriteLine("{0}{1}kb", output.Key, output.Value / 1024);
                    }
                }
            }
        }
        static void GetFileExtensions(SortedDictionary<string, Dictionary<string, double>> extensions, FileInfo[] files)
        {
            foreach (var n in files)
            {
                if (!extensions.ContainsKey(n.Extension))
                {
                    extensions.Add(n.Extension, new Dictionary<string, double>
                                    {{string.Format("--{0} - ", n.Name), n.Length}});
                }
                else
                {
                    extensions[n.Extension].Add(string.Format("--{0} - ", n.Name), n.Length);
                }
            }
        }
    }
}
