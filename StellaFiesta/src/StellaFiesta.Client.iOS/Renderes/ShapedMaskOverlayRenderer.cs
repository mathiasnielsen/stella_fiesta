using System;
using System.ComponentModel;
using StellaFiesta.Client.Controls;
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
                NativeView.Layer.CornerRadius = 25;
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

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            try
            {
                NativeView.Layer.CornerRadius = 25;
                NativeView.BackgroundColor = UIColor.Orange;
                NativeView.Layer.MasksToBounds = false;
                NativeView.ClipsToBounds = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("XXX " + ex.Message);
            }
        }
    }
}
