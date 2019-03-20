using StellaFiesta.Client.Core;
using StellaFiesta.Client.Enums;
using StellaFiesta.Client.Tools;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Common
{
    public abstract class HomeViewBase : BindableViewBase<HomeViewModel>
    {
    }

    public partial class HomeView : HomeViewBase
    {
        public HomeView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            SetSVGImage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            profile_image.Load();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            profile_image.Unload();
        }

        private void SetSVGImage()
        {
            // Need to be set before appearing (otherwise we get an object null ref)
            var profilePlaceholderImage = "StellaFiesta.Client.Assets.Images.tiger_head.svg";
            profile_image.PlaceholderSVGFilePath = profilePlaceholderImage;
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var transitionType = TransitionType.Flip;
            var transitionNavigationPage = Parent as TransitionNavigationPage;

            if (transitionNavigationPage != null)
            {
                transitionNavigationPage.TransitionType = transitionType;
                await Navigation.PushAsync(new PlaygroundView());
                transitionNavigationPage.TransitionType = TransitionType.Default;
            }
        }
    }
}
