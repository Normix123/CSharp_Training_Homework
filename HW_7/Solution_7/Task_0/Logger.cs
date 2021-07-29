using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task_0
{
    public class Logger
    {
        private readonly List<string> _list = new();
        private readonly DataWriter _dataWriter;

        public Logger(string fileName)
        {
            _dataWriter = new DataWriter(fileName);
        }

        public void Track(dynamic obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var type = obj.GetType();

            var attributes = type.GetCustomAttributes(typeof(TrackingEntity), true);

            if (attributes.Length == 0) return;

            // Flags to consider all field access modifiers (not only public by default)
            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            foreach (var field in type.GetFields(flags))
                ProcessingAttribute(field);

            foreach (var property in type.GetProperties(flags))
                ProcessingAttribute(property);

            // Method for finding field or property attributes
            void ProcessingAttribute(dynamic property)
            {
                var customAttributes = property.GetCustomAttributes(typeof(TrackingProperty), true);

                // Fields or properties can be multiple
                foreach (var a in customAttributes)
                    _list.Add(
                        ((TrackingProperty) a).PropertyName == null
                            ? $"{property.Name} : {property.GetValue(obj)}"
                            : $"{((TrackingProperty) a).PropertyName} : {property.GetValue(obj)}");
            }

            // Write file
            _dataWriter.Write(_list);

            _list.Clear();
        }
    }
}