using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class ProfileViewModel : BindableViewModelBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly INavigationService navigationService;

        private string _userName;
        private string _imageUrl;

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
            get { return _userName; }
            set { Set(ref _userName, value); }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { Set(ref _imageUrl, value); }
        }

        public override async Task OnViewInitializedAsync(Dictionary<string, string> navigationParameters)
        {
            var profile = await authenticationService.GetProfileAsync(imageSize: 200);
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
