using System;
using System.Globalization;
using Xamarin.Forms;

namespace StellaFiesta.Client.Converters
{
    public class WeekDayToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                var isWeekendDay = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                var isPast = date.Date < DateTime.Now.Date;
                if (isPast)
                {
                    return Color.Gray.MultiplyAlpha(0.8);
                }

                if (isWeekendDay)
                {
                    return Color.Gray.MultiplyAlpha(0.1);
                }
            }

            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
