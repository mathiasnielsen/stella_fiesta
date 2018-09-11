using System;
using System.Collections.Generic;
using System.Linq;

namespace StellaFiesta.Client.CoreStandard
{
    public static class CalendarInfoProvider
    {
        public static List<DateTime> GetDaysInMonth(DateTime dateTime)
        {
            var daysInMonthCount = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            var daysInMonth = Enumerable.Range(1, daysInMonthCount)
                                        .Select(day => new DateTime(dateTime.Year, dateTime.Month, day))
                                        .ToList();
            return daysInMonth;
        }
    }
}
