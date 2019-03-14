using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using StellaFiesta.Client.Controls;
using StellaFiesta.Client.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ShapedMaskGrid), typeof(ShapedMaskOverlayRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class ShapedMaskOverlayRenderer : ViewRenderer<ShapedMaskGrid, UIView>
    {
        private const string BorderLayerName = nameof(BorderLayerName);

        protected override void OnElementChanged(ElementChangedEventArgs<ShapedMaskGrid> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
            {
                return;
            }

            CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (DoesChangesRequestRedraw(e.PropertyName))
            {
                CreateCircle();
            }
        }

        private static bool DoesChangesRequestRedraw(string propertyName)
        {
            return
                propertyName == VisualElement.HeightProperty.PropertyName
                || propertyName == VisualElement.WidthProperty.PropertyName
                || propertyName == ShapedMaskGrid.BorderColorProperty.PropertyName
                || propertyName == ShapedMaskGrid.BorderThicknessProperty.PropertyName;
        }

        private void CreateCircle()
        {
            try
            {
                var shapedMaskGrid = Element;
                var minSize = Math.Min(shapedMaskGrid.Width, shapedMaskGrid.Height);
                var borderColor = shapedMaskGrid.BorderColor.ToUIColor().CGColor;
                var borderWidth = shapedMaskGrid.BorderThickness;

                // Circles
                NativeView.Layer.CornerRadius = (nfloat)(minSize / 2.0);
                NativeView.Layer.MasksToBounds = false;
                NativeView.BackgroundColor = Element.BackgroundColor.ToUIColor();
                NativeView.ClipsToBounds = true;

                // Border
                RemovePreviouslyAddedBorderLayers();
                var externalBorder = new CALayer
                {
                    Name = BorderLayerName,
                    CornerRadius = NativeView.Layer.CornerRadius,
                    Frame = new CGRect(-.5, -.5, minSize + 1, minSize + 1),
                    BorderColor = shapedMaskGrid.BorderColor.ToCGColor(),
                    BorderWidth = shapedMaskGrid.BorderThickness
                };

                NativeView.Layer.AddSublayer(externalBorder);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }

        private void RemovePreviouslyAddedBorderLayers()
        {
            var sublayers = NativeView.Layer.Sublayers;
            if (sublayers != null)
            {
                var borderLayers = sublayers.Where(p => p.Name == BorderLayerName);
                foreach (var layer in borderLayers)
                {
                    layer.RemoveFromSuperLayer();
                }
            }
        }
    }
}
