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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tigerSvgPath = "StellaFiesta.Client.Assets.Images.tiger.svg";
            var assembly = this.GetType().Assembly;

            profile_svgImage.SvgPath = tigerSvgPath;
            profile_svgImage.SvgAssembly = assembly;
        }
    }
}
