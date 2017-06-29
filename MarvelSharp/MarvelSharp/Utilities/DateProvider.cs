using System;
using MarvelSharp.Interfaces;

namespace MarvelSharp.Utilities
{
    public class DateProvider : IDateProvider
    {
        public DateTime GetCurrentTime() => DateTime.Now;
    }
}
