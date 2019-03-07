using StellaFiesta.Client.CoreStandard;

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

            // Will be fullscreen
            // Do not do this, in order to not show the background of the statusbar (which is white).
            ////On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
    }
}
