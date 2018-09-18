using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Account
{
    public abstract class SignInViewBase : BindableViewBase<SignInViewModel>
    {
    }

    public partial class SignInView : SignInViewBase
    {
        public event EventHandler FacebookSignInClicked;

        public SignInView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnFacebookSignInClicked(object sender, System.EventArgs e)
        {
            FacebookSignInClicked?.Invoke(sender, e);
        }
    }
}