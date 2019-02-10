using System;
using System.Collections.Generic;

namespace StellaFiesta.Client.CoreStandard
{
    public static class BookingCalendarUtility
    {
        public static List<BookingDayViewModel> GetDaysInMonth(DateTime selectedDate)
        {
            var daysInMonth = CalendarInfoProvider.GetDaysInMonth(selectedDate);
            var tempBookingDays = new List<BookingDayViewModel>();
            var currentDate = DateTime.Now.Date;
            foreach (var day in daysInMonth)
            {
                tempBookingDays.Add(
                    new BookingDayViewModel(
                        day.DayOfWeek.ToString(),
                        day,
                        isBooked: false,
                        imageUrl: "StellaFiesta.Client.CoreStandard.Images.nepal.png"));
            }

            return tempBookingDays;
        }
    }
}
