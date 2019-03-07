using System;
using StellaFiesta.Client;
using StellaFiesta.Client.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ShapedMaskOverlay), typeof(ShapedMaskOverlayRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class ShapedMaskOverlayRenderer : ViewRenderer<ShapedMaskOverlay, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ShapedMaskOverlay> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var maskedView = new UIView();
                maskedView.Layer.MasksToBounds = false;
                // AHHH! I do not know.
            }

            if (e.OldElement != null)
            {
                // Unhook
            }

            if (e.NewElement != null)
            {
                // Hook up
            }
        }
    }
}
