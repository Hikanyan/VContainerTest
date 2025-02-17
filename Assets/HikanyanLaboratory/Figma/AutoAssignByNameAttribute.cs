using System;

namespace HikanyanLaboratory.Figma
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AutoAssignByNameAttribute : Attribute
    {
        public AutoAssignByNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}