using System;
using MarvelSharp.Internal.Interfaces;

namespace MarvelSharp.Internal.Utilities
{
    public class DateProvider : IDateProvider
    {
        public DateTime GetCurrentTime() => DateTime.Now;
    }
}
