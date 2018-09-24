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
        private const int AnimationDuration = 2000;
        private readonly Effect fontEffect;

        public SignInView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            fontEffect = new SillyFontEffect();
            login_facebook_btn.Effects.Add(fontEffect);

            backgroundImage.Opacity = 0;
            title_label.Opacity = 0;
            login_facebook_btn.Opacity = 0;
            login_facebook_btn.TranslationY = 40;
        }

        public event EventHandler FacebookSignInClicked;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var imageResource = ImageSource.FromResource("StellaFiesta.Client.forden.jpg", this.GetType().Assembly);
            backgroundImage.Source = imageResource;

            ShowAnimations();
        }

        private void ShowAnimations()
        {
            BackgroundImageAnimations();
            WelcomeLabelAnimations();
            FacebookButtonAnimations();
        }

        private void BackgroundImageAnimations()
        {
            backgroundImage.FadeTo(1, AnimationDuration);
        }

        private void WelcomeLabelAnimations()
        {
            title_label.FadeTo(1, AnimationDuration);
        }

        private void FacebookButtonAnimations()
        {
            login_facebook_btn.FadeTo(1, AnimationDuration);
            login_facebook_btn.TranslateTo(0, 0, AnimationDuration, Easing.CubicOut);
        }

        private void OnFacebookSignInClicked(object sender, EventArgs e)
        {
            FacebookSignInClicked?.Invoke(sender, e);
        }
    }
}