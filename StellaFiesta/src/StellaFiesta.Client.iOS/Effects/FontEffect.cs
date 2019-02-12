using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace StellaFiesta.Client.iOS
{
    /// <summary>
    /// REMEMBER!
    /// 1. Install the font and check out the actual name of the font
    /// 2. Also, include the Font in the Info.plist
    /// </summary>
    ////public abstract class FontEffect : PlatformEffect
    public abstract class FontEffect
    {
        ////private UIFont originalFont;

        ////protected abstract string FontName { get; }

        ////protected override void OnAttached()
        ////{
        ////    if (Element is Label)
        ////    {
        ////        var label = Control as UILabel;
        ////        originalFont = label.Font;
        ////        label.Font = UIFont.FromName(FontName, label.Font.PointSize);
        ////    }

        ////    if (Element is Button)
        ////    {
        ////        var button = Control as UIButton;
        ////        originalFont = button.TitleLabel.Font;
        ////        var font = UIFont.FromName(FontName, button.TitleLabel.Font.PointSize);
        ////        button.TitleLabel.Font = font;
        ////    }
        ////}

        ////protected override void OnDetached()
        ////{
        ////    if (originalFont != null)
        ////    {
        ////        if (Element is Label)
        ////        {
        ////            var label = Control as UILabel;
        ////            label.Font = originalFont;
        ////        }

        ////        if (Element is Button)
        ////        {
        ////            var button = Control as UIButton;
        ////            button.TitleLabel.Font = originalFont;
        ////        }
        ////    }
        ////}
    }
}
