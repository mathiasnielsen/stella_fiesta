using System;
using System.ComponentModel;
using StellaFiesta.Client.Controls;
using StellaFiesta.Client.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IntelligentButton), typeof(IntelligentButtonRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class IntelligentButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
                SetPadding();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == IntelligentButton.ButtonPaddingProperty.PropertyName)
            {
                SetPadding();
            }
        }

        private void SetPadding()
        {
            var button = Element as IntelligentButton;
            var padding = new UIEdgeInsets(
                (float)button.Padding.Top,
                (float)button.Padding.Left,
                (float)button.Padding.Bottom,
                (float)button.Padding.Right);

            Control.ContentEdgeInsets = padding;
        }
    }
}
