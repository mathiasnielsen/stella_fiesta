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

        public void Load()
        {
            shaped_image.PropertyChanged += OnImagePropertyChanged;
        }

        public void Unload()
        {
            shaped_image.PropertyChanged -= OnImagePropertyChanged;
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
            ////var control = (IntelligentImage)bindable;
            ////var image = control.shaped_image;

            ////// Can be set here.
            ////var imageUrl = (string)newValue;
            ////image.Source = imageUrl;
        }

        private void SetSVGPlaceHolderImage()
        {
            // Need to be set before appearing (otherwise we get an object null ref)
            var assembly = this.GetType().Assembly;

            svg_placeholder_image.SvgPath = PlaceholderSVGImagePath;
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
