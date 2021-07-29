using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Ner", "", "alex", "alex", "alina");

            Directory directory = new Directory();

            directory.Add("1234567890123", book);

            foreach(var element in directory.Items)
                Console.WriteLine($"{element.Key} {element.Value.Name} {element.Value.Date} {element.Value.Writers} ");
        }
    }
}
