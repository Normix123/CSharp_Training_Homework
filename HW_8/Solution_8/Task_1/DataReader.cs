using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task_1
{
    public class DataReader
    {
        private readonly string _fullPath;

        public DataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

            _fullPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, fileName));

            if (!File.Exists(_fullPath)) throw new FileNotFoundException("File Not Found", _fullPath);
        }

        public List<(string, DateTime, DateTime)> Read()
        {
            var list = new List<(string, DateTime, DateTime)>();
            var lineNumber = 1;

            foreach (var line in File.ReadLines(_fullPath))
            {
                try
                {
                    var words = line.Split(',');

                    // It's incorrect names ignoring (can be used exception)
                    if (words[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length != 2) 
                        //throw new ArgumentException($"{words[0]} must have Name and Surname");
                    continue; 

                    // Parse to tuple
                    var name = words[0];
                    var startDate = ParseDate(words[1]);
                    var endDate = ParseDate(words[2]);

                    list.Add((name, startDate, endDate));

                    static DateTime ParseDate(string s)
                    {
                        var parts = s.Split('/');
                        return new DateTime(int.Parse(parts[2]), int.Parse(parts[0]), int.Parse(parts[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{lineNumber}: {e.Message}");
                }

                lineNumber++;
            }

            return list;
        }
    }
}