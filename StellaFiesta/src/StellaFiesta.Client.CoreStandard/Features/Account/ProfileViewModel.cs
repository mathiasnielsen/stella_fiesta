using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class ProfileViewModel : BindableViewModelBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly INavigationService navigationService;

        private string userName;
        private string imageUrl;

        public ProfileViewModel(
            IConnectivityService connectivityService,
            IAuthenticationService authenticationService,
            INavigationService navigationService)
            : base(connectivityService)
        {
            this.authenticationService = authenticationService;
            this.navigationService = navigationService;

            SignOutCommand = new RelayCommand(SignOut);
        }

        public RelayCommand SignOutCommand { get; }

        public string UserName
        {
            get { return userName; }
            set { Set(ref userName, value); }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set { Set(ref imageUrl, value); }
        }

        public override async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            var profile = await authenticationService.GetProfileAsync();
            UserName = profile.Name;
            ImageUrl = profile.ImageUrl;
        }

        private void SignOut()
        {
            authenticationService.SignOut();
            navigationService.NavigateToSignIn();
        }
    }
}
