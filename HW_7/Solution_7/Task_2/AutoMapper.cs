using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task_2
{
    public static class AutoMapper
    {
        public static void CopyTo<TS, TD>(this TS source, TD dest)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (dest == null) throw new ArgumentNullException(nameof(dest));

            var typeSource = source as Dictionary<string, string>;

            if (typeSource == null) return;

            var typeDest = dest.GetType();


            const BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                       BindingFlags.IgnoreCase;

            // Set fields to destination object
            foreach (var fieldSource in typeSource)
            {
                var fieldDest = typeDest.GetField(fieldSource.Key, flags | BindingFlags.SetProperty);
                if (fieldDest != null)
                    try
                    {
                        var value = Convert.ChangeType(fieldSource.Value, fieldDest.FieldType);
                        fieldDest.SetValue(dest, value);
                    }
                    catch (Exception)
                    {
                    }
            }

            // Set properties to destination object
            foreach (var propSource in typeSource)
            {
                var propDest = typeDest.GetProperty(propSource.Key, flags);
                if (propDest != null)
                    try
                    {
                        var value = Convert.ChangeType(propSource.Value, propDest.PropertyType);
                        propDest.SetValue(dest, value);
                    }
                    catch (Exception)
                    {
                    }
            }
        }
    }
}