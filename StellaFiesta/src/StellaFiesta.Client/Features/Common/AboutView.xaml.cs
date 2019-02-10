using StellaFiesta.Client.Core;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Common
{
    public abstract class AboutViewBase : BindableViewBase<AboutViewModel>
    {
    }

    public partial class AboutView : AboutViewBase
    {
        public AboutView()
        {
            InitializeComponent();
        }
    }
}
