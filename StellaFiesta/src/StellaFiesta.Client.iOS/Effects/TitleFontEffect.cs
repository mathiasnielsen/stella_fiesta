using StellaFiesta.Client.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(SillyFontEffect), "CustomFontEffect2")]
namespace StellaFiesta.Client.iOS
{
    public class TitleFontEffect : PlatformEffect
    {
        private const string SillyFontName = "Reanie Beanie";
        ////private const string SillyFontName = "gabiies handwritting";
        ////private const string SillyFontName = "Reenie Beanie";
        ////private const string SillyFontName = "Pacifico";

        private UIFont originalFont;

        protected override void OnAttached()
        {
            if (Element is Label)
            {
                var label = Control as UILabel;
                originalFont = label.Font;
                label.Font = UIFont.FromName(SillyFontName, label.Font.PointSize);
            }

            if (Element is Button)
            {
                var button = Control as UIButton;
                originalFont = button.TitleLabel.Font;
                var font = UIFont.FromName(SillyFontName, button.TitleLabel.Font.PointSize);
                button.TitleLabel.Font = font;
            }
        }

        protected override void OnDetached()
        {
            if (originalFont != null)
            {
                if (Element is Label)
                {
                    var label = Control as UILabel;
                    label.Font = originalFont;
                }

                if (Element is Button)
                {
                    var button = Control as UIButton;
                    button.TitleLabel.Font = originalFont;
                }
            }
        }
    }
}
