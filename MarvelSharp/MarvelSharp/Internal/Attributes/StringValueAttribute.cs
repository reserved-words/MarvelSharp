using System;

namespace MarvelSharp.Internal.Attributes
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
