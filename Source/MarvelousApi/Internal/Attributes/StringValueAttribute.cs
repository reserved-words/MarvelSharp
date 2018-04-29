using System;

namespace MarvelSharp.Internal.Attributes
{
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string resourceName)
        {
            ResourceName = resourceName;
        }
        
        public string ResourceName { get; set; }
    }
}
