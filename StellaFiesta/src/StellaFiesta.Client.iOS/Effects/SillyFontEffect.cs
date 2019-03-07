using StellaFiesta.Client.iOS;
using Xamarin.Forms;

[assembly: ResolutionGroupName("StellaFonts")]
[assembly: ExportEffect(typeof(SillyFontEffect), nameof(SillyFontEffect))]
namespace StellaFiesta.Client.iOS
{
    public class SillyFontEffect : FontEffectBase
    {
        protected override string FontName => "gabiies handwritting";
    }
}
