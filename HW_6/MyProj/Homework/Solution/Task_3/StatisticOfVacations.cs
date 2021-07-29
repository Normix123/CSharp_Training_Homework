using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    public class StatisticOfVacations : IEnumerable<Vacation> // Class for data processing
    {
        private readonly List<Vacation> _data;

        // Can be changed to any other year
        private const int Year = 2016;

        public void Add(string personName, DateTime start, DateTime end) => 
            _data.Add(new Vacation(personName, start, end));

        public void Add(Vacation record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));

            _data.Add(record);
        }


        public IEnumerator<Vacation> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        public StatisticOfVacations(string path) => _data = ReadFile(path).ToList();

        private IEnumerable<Vacation> ReadFile(string path) => BadFileReader.ReadFile(path);

        // Write file to any directory by explicitly specifying the file name
        public void WriteFile(string name, string directory) => 
            WriteJsonFile.Write(VacationsInSecondHalfOfYear(Year), name, directory);

        // Sample data for the second half of the year
        private IEnumerable<object> VacationsInSecondHalfOfYear(int year)
        {
            return from el in _data
                where el.Start.Year == year &&
                      el.Start.Month > 6
                group el by el.Person
                into key
                select new
                {
                    Name = key.Key,
                    Vacations = from p in key
                        select new
                        {
                            p.Start, p.End
                        }
                };
        }
    }
}