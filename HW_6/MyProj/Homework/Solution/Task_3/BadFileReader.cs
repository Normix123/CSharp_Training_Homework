using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Task_3
{
    public static class BadFileReader // Class for reading data
    {
        public static IEnumerable<Vacation> ReadFile(string path)
        {
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                var i = 0; // number of line

                while ((line = streamReader.ReadLine()) != null)
                {
                    var vacation = GetVacationByLine(line, ++i);
                    if (vacation != null) yield return vacation;
                }
            }
        }

        private static Vacation GetVacationByLine(string line, int numberOfLine)
        {
            var vacation = default(Vacation);

            try
            {
                var query = line.Split(',', StringSplitOptions.TrimEntries);

                vacation = new Vacation(query[0],
                    DateTime.ParseExact(query[1], @"M/d/yyyy", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(query[2], @"M/d/yyyy", CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"#{numberOfLine} Message: {ex.Message}");
            }

            return vacation;
        }
    }
}