using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task3 {
    internal static class Program {
        public static void Main(string[] args) {
            var fileFormat = args[0];
            var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = dirInfo.GetFiles(fileFormat).ToList();
            var dirs = dirInfo.GetDirectories().ToList();
            while (dirs.Count != 0) {
                var dirs2 = new List<DirectoryInfo>();
                foreach (var dir in dirs) {
                    files.AddRange(dir.GetFiles(fileFormat));
                    dirs2.AddRange(dir.GetDirectories().ToList());
                }

                dirs = dirs2;
            }

            if (files.Count == 0) {
                Console.WriteLine($"No files with {fileFormat} extention");
                return;
            }

            foreach (var file in files) {
                var res = CountLines(file.FullName);
                if (file.Directory != null) {
                    Console.WriteLine(res == -1
                        ? $"Can't count lines in '{file.Name}' from '{file.Directory.Name}'"
                        : $"Number of codelines in '{file.Name}' from '{file.Directory.Name}' is {res}");
                }
                else {
                    Console.WriteLine(res == -1
                        ? $"Can't count lines in '{file.Name}'"
                        : $"Number of codelines in '{file.Name}' is {res}");
                }
            }
        }

        private static int CountLines(string fileName) {
            if (!File.Exists(fileName)) return -1;
            var lines = File.ReadAllLines(fileName);
            return lines.Count(line => !IsACommentOrEmpty(line));
        }

        private static bool IsACommentOrEmpty(string line) {
            return string.IsNullOrEmpty(line) || line.StartsWith("//");
        }
    }
}