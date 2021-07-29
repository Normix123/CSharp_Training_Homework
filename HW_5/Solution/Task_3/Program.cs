using System;
using System.Collections.Generic;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Holiday> holidayList = new List<Holiday>()
            {
             new Holiday() { Person =  "Steve", FirstDay = new DateTime(2020, 01,2), LastDay = new DateTime(2020, 01,26) } ,
             new Holiday() { Person =  "Alex", FirstDay = new DateTime(2020, 01,12), LastDay = new DateTime(2020, 02,13) } ,
             new Holiday() { Person =  "Steve", FirstDay = new DateTime(2020, 01,27), LastDay = new DateTime(2020, 03,30) } ,
             new Holiday() { Person =  "Alex", FirstDay = new DateTime(2020, 03,20), LastDay = new DateTime(2020, 03,21) } ,
             new Holiday() { Person =  "Alina", FirstDay = new DateTime(2020, 06,20), LastDay = new DateTime(2020, 08,21) }
            };

            DataHoliday dataHoliday = new DataHoliday(holidayList);

            Console.WriteLine("Persons, who has holidays in number of Mounth:");
            foreach(var element in dataHoliday.PersonsHolidaysCountInMounth())
            Console.WriteLine($"{element.Item1} {element.Item2}");

            Console.WriteLine("Persons with average vacation:");
            foreach (var element in dataHoliday.PersonsAverageVacationDuration())
                Console.WriteLine($"{element.Item1} {element.Item2}");

            Console.WriteLine("Dates without holidays:");
            foreach (var element in dataHoliday.DatesWhithoutHolidays())
                Console.WriteLine($" from { element.Item1.ToLongDateString()} to { element.Item2.ToLongDateString()}");
        }
    }
}
