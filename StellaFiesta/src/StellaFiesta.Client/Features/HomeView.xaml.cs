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

        private void SetSVGImage()
        {
            // Need to be set before appearing (otherwise we get an object null ref)
            var tigerSvgPath = "StellaFiesta.Client.Assets.Images.tiger.svg";
            var assembly = this.GetType().Assembly;

            profile_svgImage.SvgPath = tigerSvgPath;
            profile_svgImage.SvgAssembly = assembly;
        }
    }
}
