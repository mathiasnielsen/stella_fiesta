using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Features.Account
{
    public abstract class SignInViewBase : BindableViewBase<SignInViewModel>
    {
    }

    public partial class SignInView : SignInViewBase
    {
        public SignInView()
        {
            InitializeComponent();
        }
    }
}