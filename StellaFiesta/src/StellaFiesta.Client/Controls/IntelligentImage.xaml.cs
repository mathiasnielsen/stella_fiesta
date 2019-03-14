using System;
using System.ComponentModel;
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
        private const string FallbackImageButNotUsed = "StellaFiesta.Client.Assets.Images.tiger_head.svg";

        public static BindableProperty ImageUrlProperty =
            BindableProperty.Create(
                propertyName: nameof(ImageUrl),
                returnType: typeof(string),
                declaringType: typeof(IntelligentImage),
                defaultValue: string.Empty,
                propertyChanged: OnImageUrlChanged);

        public static BindableProperty PlaceHolderSVGFilePathProperty =
            BindableProperty.Create(
                propertyName: nameof(PlaceholderSVGFilePath),
                returnType: typeof(string),
                declaringType: typeof(IntelligentImage),
                defaultValue: string.Empty,
                propertyChanged: OnPlaceholderSVGGilePathPropertyChanged);

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

        public string PlaceholderSVGFilePath
        {
            get { return (string)GetValue(PlaceHolderSVGFilePathProperty); }
            set { SetValue(PlaceHolderSVGFilePathProperty, value); }
        }

        public void Load()
        {
            shaped_image.PropertyChanged += OnImagePropertyChanged;
        }

        public void Unload()
        {
            shaped_image.PropertyChanged -= OnImagePropertyChanged;
        }

        private static void OnImageUrlChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            // Here we could set the image also, but urls also takes some time to load the first time.
            // So! we wait until the IsLoading is finished.
        }

        private static void OnPlaceholderSVGGilePathPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            var control = (IntelligentImage)bindable;
            var svgImage = control.svg_placeholder_image;
            svgImage.SvgPath = (string)newValue;
        }

        private void SetSVGPlaceHolderImage()
        {
            // Need to be set before appearing (otherwise we get an object null ref)
            var assembly = this.GetType().Assembly;
            svg_placeholder_image.SvgAssembly = assembly;
        }

        private void OnImagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Image.IsLoadingProperty.PropertyName)
            {
                if (shaped_image.IsLoading == false)
                {
                    FinishedLoading();
                }
            }
        }

        private void FinishedLoading()
        {
            var didGetImage = string.IsNullOrWhiteSpace(ImageUrl) == false;
            if (didGetImage)
            {
                shaped_image.FadeTo(1.0);
                svg_placeholder_image.FadeTo(0.0);
            }
            else
            {
                shaped_image.FadeTo(0.0);
                svg_placeholder_image.FadeTo(1.0);
            }
        }
    }
}
