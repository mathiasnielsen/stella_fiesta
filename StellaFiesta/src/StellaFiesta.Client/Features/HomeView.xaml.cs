using StellaFiesta.Client.Converters;
using StellaFiesta.Client.Core;
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

            profile_svgImage.SetBinding(
                Image.SourceProperty, new Binding("Source", source: ViewModel.ImageUrl, converter: new DebugConverter()));
        }

        private void SetSVGImage()
        {
            // Need to be set before appearing (otherwise we get an object null ref)
            var profilePlaceholderImage = "StellaFiesta.Client.Assets.Images.tiger_head.svg";
            var assembly = this.GetType().Assembly;

            profile_svgImage.SvgPath = profilePlaceholderImage;
            profile_svgImage.SvgAssembly = assembly;
        }
    }
}
