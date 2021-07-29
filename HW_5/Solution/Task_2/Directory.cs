using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace Task_2
{
    public class Directory : ArrayNode<string, Book>
    {
        public Directory() : base() { }

        public Directory(int capasity) : base(capasity) { }

        public new Book this[string key]
        {
            get
            {
                CheckKey(ref key);
                return base[key];
            }

            set
            {
                CheckKey(ref key);
                base[key] = value;
            }
        }

        public new void Add(string key, Book value)
        {
            CheckKey(ref key);
            base.Add(key, value);
        }

        public new void Update(string key, Book value)
        {
            CheckKey(ref key);
            base.Update(key, value);
        }

        public new bool TryGetValue(string key, out Book value)
        {
            CheckKey(ref key);
            return base.TryGetValue(key, out value);
        }

        public new bool Remove(string key)
        {
            CheckKey(ref key);
            return base.Remove(key);   
        }

        private void CheckKey(ref string key)
        {
            Regex regex1 = new Regex("[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}");
            Regex regex2 = new Regex("[0-9]{13}");

            if (regex1.IsMatch(key) || regex2.IsMatch(key))
            {
                Regex.Replace(key, "-", "");
            }

            else throw new ArgumentException($"{key} is wrong format.");
        }

    }
}


