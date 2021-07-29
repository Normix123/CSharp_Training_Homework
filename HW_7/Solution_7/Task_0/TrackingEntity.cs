using System;

namespace Task_0
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class TrackingEntity : Attribute
    {
    }
}