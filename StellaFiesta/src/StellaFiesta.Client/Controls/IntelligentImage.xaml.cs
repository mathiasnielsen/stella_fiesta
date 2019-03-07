using Xamarin.Forms;

namespace StellaFiesta.Client.Controls
{
    /// <summary>
    /// Intelligent image.
    /// 
    /// Circle images:
    /// https://blog.xamarin.com/elegant-circle-images-in-xamarin-forms/
    /// </summary>
    public partial class IntelligentImage : ContentView
    {
        private const string PlaceholderSVGImagePath = "StellaFiesta.Client.Assets.Images.tiger_head.svg";

        public static BindableProperty ImageUrlProperty =
            BindableProperty.Create(
                propertyName: nameof(ImageUrl),
                returnType: typeof(string),
                declaringType: typeof(IntelligentImage),
                defaultValue: string.Empty,
                propertyChanged: OnImageUrlChanged);

        public IntelligentImage()
        {
            InitializeComponent();
            SetSVGPlaceHolderImage();
        }

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        private static void OnImageUrlChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (IntelligentImage)bindable;
            var image = control.shaped_image;
            var svgImage = control.svg_placeholder_image;

            var imageUrl = (string)newValue;
            image.Source = imageUrl;

            var didGetImage = string.IsNullOrWhiteSpace(imageUrl) == false;
            if (didGetImage)
            {
                ////image.FadeTo(1.0);
                ////svgImage.FadeTo(0.0);
            }
            else
            {
                ////image.FadeTo(0.0);
                ////svgImage.FadeTo(1.0);
            }
        }

        private void SetSVGPlaceHolderImage()
        {
            // Need to be set before appearing (otherwise we get an object null ref)
            var assembly = this.GetType().Assembly;

            svg_placeholder_image.SvgPath = PlaceholderSVGImagePath;
            svg_placeholder_image.SvgAssembly = assembly;
        }
    }
}
