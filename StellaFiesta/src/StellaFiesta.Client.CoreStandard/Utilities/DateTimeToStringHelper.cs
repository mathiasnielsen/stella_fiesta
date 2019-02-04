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

        public static string GetTitleFromDate(DateTime dateTime)
        {
            var day = dateTime.GetDayNumberInMonth();
            var weekdayName = dateTime.GetWeekdayName();
            var month = dateTime.GetMonthName();
            var year = dateTime.GetYear();

            return $"{day} ({weekdayName}), {month}, {year}";
        }
    }
}
