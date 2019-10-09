using Persia;
using System;

namespace BEFOYS.Common.Convert
{
    public static class DateConvert
    {
        public static string ToPersian(this DateTime date)
        {
            return Persia.Calendar.ConvertToPersian(date).Persian;
        }
    }
}
