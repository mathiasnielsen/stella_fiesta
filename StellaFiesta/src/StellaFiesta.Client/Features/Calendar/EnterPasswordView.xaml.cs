using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace StellaFiesta.Client.Features.Calendar
{
    public abstract class EnterPasswordViewBase : BindableViewBase<EnterPasswordViewModel>
    {
    }

    public partial class EnterPasswordView : EnterPasswordViewBase
    {
        public EnterPasswordView()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
    }
}
