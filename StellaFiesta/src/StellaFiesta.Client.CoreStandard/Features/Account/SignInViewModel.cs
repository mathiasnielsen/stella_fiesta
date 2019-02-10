using System.Threading.Tasks;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class SignInViewModel : BindableViewModelBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly INavigationService navigationService;

        public SignInViewModel(
            IConnectivityService connectivityService,
            IAuthenticationService authenticationService,
            INavigationService navigationService)
            : base(connectivityService)
        {
            this.authenticationService = authenticationService;
            this.navigationService = navigationService;
        }

        public override Task OnLoadAsync()
        {
            if (authenticationService.IsLoggedIn)
            {
                navigationService.NavigateToHome();
            }

            return base.OnLoadAsync();
        }
    }
}
