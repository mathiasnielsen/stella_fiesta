using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Account
{
    ////https://github.com/xamarin/xamarin-forms-samples/blob/master/WorkingWithImages/WorkingWithImages/EmbeddedImagesXaml.xaml.cs
    public abstract class SignInViewBase : BindableViewBase<SignInViewModel>
    {
    }

    public partial class SignInView : SignInViewBase
    {
        public event EventHandler FacebookSignInClicked;

        private readonly Effect fontEffect;

        public SignInView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            fontEffect = new SillyFontEffect();
            login_facebook_btn.Effects.Add(fontEffect);

            backgroundImage.Opacity = 0;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var imageResource = ImageSource.FromResource("StellaFiesta.Client.forden.jpg", this.GetType().Assembly);
            backgroundImage.Source = imageResource;

            ShowAnimations();
        }

        private void ShowAnimations()
        {
            FadeInImage();
        }

        private void FadeInImage()
        {
            backgroundImage.FadeTo(1, 2000);
        }

        private void OnFacebookSignInClicked(object sender, System.EventArgs e)
        {
            FacebookSignInClicked?.Invoke(sender, e);
        }
    }
}