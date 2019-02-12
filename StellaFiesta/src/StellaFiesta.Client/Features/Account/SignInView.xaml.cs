using System;
using StellaFiesta.Client.CoreStandard;
using StellaFiesta.Client.Effects;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Account
{
    ////https://github.com/xamarin/xamarin-forms-samples/blob/master/WorkingWithImages/WorkingWithImages/EmbeddedImagesXaml.xaml.cs
    public abstract class SignInViewBase : BindableViewBase<SignInViewModel>
    {
    }

    public partial class SignInView : SignInViewBase
    {
        private const string FordImagePath = "StellaFiesta.Client.Assets.Images.forden.jpg";
        private const int AnimationDurationInMs = 1000;
        private const int WelcomeTranslationYOffset = 40;

        public SignInView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            title_label.Text = $"Welcome{Environment.NewLine}to{Environment.NewLine}Stella Fiesta";
            ////login_facebook_btn.Effects.Add(new SillyFontEffect());

            title_label.Opacity = 0;
            login_facebook_btn.Opacity = 0;
            login_facebook_btn.TranslationY = WelcomeTranslationYOffset;

            var backgroundImageResource = ImageSource.FromResource(FordImagePath, this.GetType().Assembly);
            backgroundImage.Source = backgroundImageResource;
        }

        public event EventHandler FacebookSignInClicked;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowAnimations();
        }

        private void ShowAnimations()
        {
            WelcomeLabelAnimations();
            FacebookButtonAnimations();
        }

        private void WelcomeLabelAnimations()
        {
            title_label.FadeTo(1, AnimationDurationInMs);
        }

        private void FacebookButtonAnimations()
        {
            login_facebook_btn.FadeTo(1, AnimationDurationInMs);
            login_facebook_btn.TranslateTo(0, 0, AnimationDurationInMs, Easing.CubicOut);
        }

        private void OnFacebookSignInClicked(object sender, EventArgs e)
        {
            FacebookSignInClicked?.Invoke(sender, e);
        }
    }
}