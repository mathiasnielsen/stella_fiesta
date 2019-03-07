using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Foundation;
using StellaFiesta.Client.Controls;
using StellaFiesta.Client.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ShapedImage), typeof(ShapedImageRenderer))]
namespace StellaFiesta.Client.iOS
{
    [Preserve(AllMembers = true)]
    public class ShapedImageRenderer : ImageRenderer
    {
        private const string BorderLayerName = nameof(BorderLayerName);

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
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
                || propertyName == ShapedImage.BorderColorProperty.PropertyName
                || propertyName == ShapedImage.BorderThicknessProperty.PropertyName
                || propertyName == ShapedImage.FillColorProperty.PropertyName;
        }

        private void CreateCircle()
        {
            try
            {
                var minSize = Math.Min(Element.Width, Element.Height);
                var shapedImage = (ShapedImage)Element;
                var fillColor = shapedImage.FillColor.ToUIColor();
                var borderColor = shapedImage.BorderColor.ToUIColor().CGColor;
                var borderWidth = shapedImage.BorderThickness;

                // Circles
                Control.Layer.CornerRadius = (nfloat)(minSize / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.BackgroundColor = fillColor;
                Control.ClipsToBounds = true;

                // Border
                ////RemovePreviouslyAddedBorderLayers();
                ////var externalBorder = new CALayer
                ////{
                ////    Name = BorderLayerName,
                ////    CornerRadius = Control.Layer.CornerRadius,
                ////    Frame = new CGRect(-.5, -.5, minSize + 1, minSize + 1),
                ////    BorderColor = ((ShapedImage)Element).BorderColor.ToCGColor(),
                ////    BorderWidth = ((ShapedImage)Element).BorderThickness
                ////};

                ////Control.Layer.AddSublayer(externalBorder);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }

        private void RemovePreviouslyAddedBorderLayers()
        {
            var sublayers = Control.Layer.Sublayers;
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
