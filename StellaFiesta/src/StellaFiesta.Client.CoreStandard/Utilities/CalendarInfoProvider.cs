using System;
using System.Collections.Generic;

namespace StellaFiesta.Client.CoreStandard
{
    public static class CalendarInfoProvider
    {
        public static List<DateTime> GetDaysInMonth(DateTime dateTime)
        {
            var daysInMonth = new List<DateTime>();

            var daysInMonthCount = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            for (int dayIndex = 0; dayIndex < daysInMonthCount; dayIndex++)
            {
                var dayTime = new DateTime(dateTime.Year, dateTime.Month, dayIndex + 1, 12, 0, 0);
                daysInMonth.Add(dayTime);
            }

            return daysInMonth;
        }

        public static List<DateTime> GetAllMonths()
        {
            var months = new List<DateTime>();
            for (int monthIndex = 0; monthIndex < 12; monthIndex++)
            {
                var monthInYear = new DateTime(DateTime.MinValue.Year, monthIndex + 1, DateTime.MinValue.Day);
                months.Add(monthInYear);
            }

            return months;
        }

        public static List<DateTime> GetYearsFromNowAndInFuture(int yearsInFuture)
        {
            var years = new List<DateTime>();
            for (int yearsIndex = 0; yearsIndex < yearsInFuture; yearsIndex++)
            {
                var year = new DateTime(DateTime.Now.AddYears(yearsIndex).Year, DateTime.MinValue.Month, DateTime.MinValue.Day);
                years.Add(year);
            }

            return years;
        }
    }
}
