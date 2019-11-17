using System;

namespace MarvelSharp.Internal.Attributes
{
    internal class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string resourceName)
        {
            ResourceName = resourceName;
        }
        
        public string ResourceName { get; set; }
    }
}
