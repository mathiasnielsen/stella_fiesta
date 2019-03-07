using Xamarin.Forms;

namespace StellaFiesta.Client.Effects
{
    public class SillyFontEffect : RoutingEffect
    {
        public SillyFontEffect()
            : base($"StellaFonts.{nameof(SillyFontEffect)}")
        {
        }
    }
}
