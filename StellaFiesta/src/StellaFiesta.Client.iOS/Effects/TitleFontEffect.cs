using StellaFiesta.Client.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("StellaFonts")]
[assembly: ExportEffect(typeof(TitleFontEffect), "Test1")]
namespace StellaFiesta.Client.iOS
{
    public class TitleFontEffect : PlatformEffect
    {
        private UIFont originalFont;

        protected string FontName => "Monoton";

        protected override void OnAttached()
        {
            if (Element is Label)
            {
                var label = Control as UILabel;
                originalFont = label.Font;
                label.Font = UIFont.FromName(FontName, label.Font.PointSize);
            }

            if (Element is Button)
            {
                var button = Control as UIButton;
                originalFont = button.TitleLabel.Font;
                var font = UIFont.FromName(FontName, button.TitleLabel.Font.PointSize);
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
