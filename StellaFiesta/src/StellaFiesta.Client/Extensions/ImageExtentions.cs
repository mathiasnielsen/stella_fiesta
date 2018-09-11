using System.Reflection;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public static class ImageExtentions
    {
        public static ImageSource GetImageSource(this CarDayViewModel carDay)
        {
            var assembly = carDay.GetType().GetTypeInfo().Assembly;
            return ImageSource.FromResource(carDay.ImageUrl, assembly);
        }
    }
}
