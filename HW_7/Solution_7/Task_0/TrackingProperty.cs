using System;

namespace Task_0
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class TrackingProperty : Attribute
    {
        public string PropertyName { get; set; }
    }
}