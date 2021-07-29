using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    public class Vacation : IEnumerable<DateTime>
    {
        public string Person { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public int Length => (End - Start).Days + 1;

        public Vacation(string person, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(person))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(person));
            }

            if (end < start)
            {
                throw new ArgumentException("'end' date must be greater or equals to 'start' date");
            }

            Person = person;
            Start = start.Date;
            End = end.Date;
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            for (var date = Start; date <= End; date = date.AddDays(1))
            {
                yield return date;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<int> GetMonths() => this.Select(y => y.Month).Distinct();

        public override string ToString() => $"{Person} {Start:d} - {End:d} ({Length} day(s))";
    }
}