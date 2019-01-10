using System;

namespace StellaFiesta.Client.CoreStandard.Utilities
{
    public static class DateTimeToStringHelper
    {
        public static string GetWeekdayName(this DateTime dateTime)
        {
            return dateTime.ToString("dddd");
        }

        public static string GetMonthName(this DateTime dateTime)
        {
            return dateTime.ToString("MMMM");
        }

        public static string GetDayNumberInMonth(this DateTime dateTime)
        {
            return dateTime.ToString("dd");
        }

        public static string GetYear(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy");
        }
    }
}
