using System;
using MarvelSharp.Internal.Interfaces;

namespace MarvelSharp.Internal.Utilities
{
    internal class DateProvider : IDateProvider
    {
        public DateTime GetCurrentTime() => DateTime.Now;
    }
}
