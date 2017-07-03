using System;

namespace MarvelSharp.Attributes
{
    internal class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
