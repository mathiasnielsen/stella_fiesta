using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Features.Account
{
    public abstract class ProfileViewBase : BindableViewBase<ProfileViewModel>
    {
    }

    public partial class ProfileView : ProfileViewBase
    {
        public ProfileView()
        {
            InitializeComponent();
        }
    }
}
