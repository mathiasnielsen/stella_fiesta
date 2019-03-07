using StellaFiesta.Client.iOS;
using Xamarin.Forms;

[assembly: ExportEffect(typeof(TitleFontEffect), nameof(TitleFontEffect))]
namespace StellaFiesta.Client.iOS
{
    public class TitleFontEffect : FontEffectBase
    {
        protected override string FontName => "Monoton";
    }
}
