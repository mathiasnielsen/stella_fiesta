using Android.Graphics;
using Android.Widget;
using StellaFiesta.Client.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(SillyFontEffect), "CustomFontEffect")]
namespace StellaFiesta.Client.Droid
{
    public class SillyFontEffect : PlatformEffect
    {
        private const string SillyFontName = "gabiies handwritting.ttf";

        private Typeface originalFont;

        protected override void OnAttached()
        {
            if (Element is Label)
            {
                var label = Control as TextView;
                originalFont = label.Typeface;
                var font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, SillyFontName);
                label.Typeface = font;
            }
        }

        protected override void OnDetached()
        {
            if (Element is Label && originalFont != null)
            {
                var label = Control as TextView;
                label.Typeface = originalFont;
            }
        }
    }
}
