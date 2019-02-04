﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace StellaFiesta.Client.Converters
{
    public class DateTimeToDayNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                return $"{date.Day}.";
            }

            throw new ArgumentException("Value is not of the type DateTime.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
