using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace StellaFiesta.Client.Converters
{
    public class EmbeddedImageConverter : IValueConverter
    {
        public Type ResolvingAssemblyType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageUrl = (value ?? "").ToString();
            if (string.IsNullOrEmpty(imageUrl))
            {
                return null;
            }

            var assembly = ResolvingAssemblyType?.GetTypeInfo().Assembly;
            var imageSource = ImageSource.FromResource(imageUrl, assembly);

            return imageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
