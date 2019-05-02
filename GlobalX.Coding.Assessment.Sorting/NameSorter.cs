﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GlobalX.Coding.Assessment.Sorting
{
    public abstract class NameSorter
    {
        public void MainMethod(string filename)
        {
            if (!File.Exists(filename))
            {
                FileNotFound();
                return;
            }

            var names = GetNames(filename);

            IEnumerable<Name> sortedNames = null;
            var sw = new Stopwatch();
            sw.Start();

            sortedNames = Sort(names);

            sw.Stop();
            WriteList(sortedNames);

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine($"\nTime taken {sw.ElapsedMilliseconds} ms");
            //Console.ForegroundColor = ConsoleColor.White;
        }

        private void FileNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFile Not Found");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static Name[] GetNames(string filename)
        {
            var names = File.ReadAllLines(filename);
            var result = names.Select(a => new Name(a)).ToArray();
            return result;
        }

        private void WriteList(IEnumerable<Name> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines("sorted-names-list.txt", lines.Select(a => a.ToString()).ToArray());
        }

        public abstract Name[] Sort(Name[] names);
    }
}