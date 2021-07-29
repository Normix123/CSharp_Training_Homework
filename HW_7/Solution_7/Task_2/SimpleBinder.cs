using System;
using System.Collections.Generic;
using Task_2;

namespace Task_2
{
    internal class SimpleBinder
    {
        private static SimpleBinder _instance;
        public static dynamic ObjectBinded { get; private set; }

        private SimpleBinder() { }
        
        private static dynamic Binder(Type type, Dictionary<string, string> dictionary)
        {
            dynamic obj = Activator.CreateInstance(type);

            AutoMapper.CopyTo(dictionary, obj);

            return obj;
        }

        public static SimpleBinder GetInstance(Type type, Dictionary<string, string> dictionary)
        {
            if (_instance == null)
                _instance = new SimpleBinder();

            ObjectBinded = Binder(type, dictionary);
            
            return _instance;
        }
    }
}