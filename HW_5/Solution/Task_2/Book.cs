using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Task_2
{
    public class Book 
    {
        private readonly SortedSet<string> _writers;

        public string Name { get; private set; }

        public string Date { get; private set; }

        public IEnumerable<string> Writers
        {
            get
            {
                foreach (var element in _writers)
                    yield return element;    
            }
            private set { }
        }

        public Book (string name, string dateOfPublication = "", params string[] writers)
        {
            
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name can't be empty or null");
            Name = name;

            DateTime date;
            if (DateTime.TryParse(dateOfPublication, out date) || string.IsNullOrEmpty(dateOfPublication)) Date = dateOfPublication;
            else throw new ArgumentException("Incorrect attempt of Date");
            
            _writers = new SortedSet<string>();
            if (writers != null) 
            {
                foreach (var element in writers)
                    _writers.Add(element);
            }
        }        
    }
}
