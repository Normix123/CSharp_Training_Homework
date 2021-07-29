using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3
{
    public class DataHoliday
    {
        private List<Holiday> _holidayList;

        public DataHoliday(List<Holiday> holidays)
        {
            if (holidays == null ) throw new ArgumentNullException($"{nameof(holidays)}");

            if (holidays.Count < 1 || !IsCorrect(holidays)) throw new ArgumentException($"{nameof(holidays)}");

            _holidayList = new List<Holiday>(holidays.Capacity);

            foreach (var element in holidays)
                _holidayList.Add(element);
        }

        public DataHoliday(int capacity)
        {
            if (capacity > 0) 
            _holidayList = new List<Holiday>(capacity);
            else throw new ArgumentOutOfRangeException($"{nameof(capacity)}");
        }

        public Holiday this[int index]
        {
            get
            {
                return _holidayList[index];
            }

            set 
            {
                CheckHoliday(value);
                _holidayList[index] = value;
            }
        }

        public double DaysAverageVacationDuration() //Task 2
        {
            return _holidayList.Average(x => (x.LastDay - x.FirstDay).TotalDays + 1);
        }

        public IEnumerable<(string,double)> PersonsAverageVacationDuration() //Task 3
        {
            var q = from holiday in _holidayList
                    group holiday by holiday.Person into person
                    select new
                    {
                        Name = person.Key,
                        Duration = person.Average(x => (x.LastDay - x.FirstDay).TotalDays + 1)
                    };
            foreach (var element in q)
                yield return (element.Name, element.Duration);
        }

        public IEnumerable<(int, int)> PersonsHolidaysCountInMounth()//Task 4
        {
            var i = 1;
            while (i <= 12)
            {
                var q = from holiday in _holidayList
                        where holiday.FirstDay.Month == i || holiday.LastDay.Month == i
                        group _holidayList by holiday.Person into g
                        select (true);

                yield return (i, q.Count());

                i++;
            }
        }

        public IEnumerable<(DateTime, DateTime)> DatesWhithoutHolidays()//Task 5
        {
            DateTime dateTimeStart = new DateTime(2020, 1, 1);
            DateTime dateTimeEnd = new DateTime(2020, 1, 1);

            var flag = true;

            var day = 1;
            while (day <= 366)
            {
                day++;
                var q = from holiday in _holidayList
                        where (holiday.FirstDay.DayOfYear > day && holiday.LastDay.DayOfYear > day)
                        || (holiday.FirstDay.DayOfYear < day && holiday.LastDay.DayOfYear < day)
                        select (day);
                if (q.Count() == _holidayList.Count)
                {
                    if (flag == false)
                    {
                        dateTimeStart = new DateTime(2020, 1, 1);
                        dateTimeStart = dateTimeStart.AddDays(day - 2);
                        dateTimeEnd = new DateTime(2020, 1, 1);
                        dateTimeEnd = dateTimeEnd.AddDays(day - 2);
                        flag = true;
                    }

                    if (day - 1 == dateTimeEnd.DayOfYear)
                    {
                        dateTimeEnd = dateTimeEnd.AddDays(1);
                    }

                    else
                    {
                        flag = false;
                        yield return (dateTimeStart, dateTimeEnd);
                        continue;
                    }
                }
            }
            yield return (dateTimeStart, dateTimeEnd.AddDays(-1));
        }

        private bool IsCorrect(List<Holiday> _holidayList) // Task 6
        {

            var query1 = from x in _holidayList
                         group x by x.Person into g
                         where g.Count() > 1
                         select g.Key;

            foreach (var element in query1)
            {
                var query2 = from e in _holidayList
                        where e.Person == element
                        select (e.FirstDay, e.LastDay);

                foreach(var e in query2)
                {
                    var ex = from per in query2
                             where Math.Abs(e.LastDay.DayOfYear - per.LastDay.DayOfYear) + Math.Abs(e.FirstDay.DayOfYear - per.FirstDay.DayOfYear) < Math.Abs(e.LastDay.DayOfYear - e.FirstDay.DayOfYear) + Math.Abs(per.LastDay.DayOfYear - per.FirstDay.DayOfYear) 
                             && !(e.FirstDay==per.FirstDay && e.LastDay==per.LastDay)
                             select element;

                    foreach (var t in ex) return false;
                }
            }
            return true;     
        }
        
        private void CheckHoliday(Holiday holiday)
        {
            if (holiday == null) throw new ArgumentNullException($"{nameof(holiday)}");
            if (holiday.FirstDay.Ticks < holiday.LastDay.Ticks) throw new ArgumentException($"{nameof(holiday.FirstDay)} must be less than {nameof(holiday.LastDay)}");
            
            Regex reg = new Regex("[A-z,' ',',']");

            if(!reg.IsMatch(holiday.Person)) throw new ArgumentException($"{nameof(holiday.Person)}");
        }
    }
}

