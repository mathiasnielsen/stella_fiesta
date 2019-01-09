using System;
using System.Globalization;
using Xamarin.Forms;

namespace StellaFiesta.Client.Converters
{
    public class BookingStateToTextBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isBooked)
            {
                return isBooked ? "booked" : "free";
            }

            throw new ArgumentException("Booking state is not a boolean value.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
