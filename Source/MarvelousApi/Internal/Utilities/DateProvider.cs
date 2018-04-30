using System;
using MarvelousApi.Internal.Interfaces;

namespace MarvelousApi.Internal.Utilities
{
    public class DateProvider : IDateProvider
    {
        public DateTime GetCurrentTime() => DateTime.Now;
    }
}
