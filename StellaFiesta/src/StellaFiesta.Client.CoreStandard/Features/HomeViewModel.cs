using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class HomeViewModel : BindableViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;

        private string _imageUrl;

        public HomeViewModel(
            IConnectivityService connectivityService,
            INavigationService navigationService,
            IAuthenticationService authenticationService)
            : base(connectivityService)
        {
            _navigationService = navigationService;
            _authenticationService = authenticationService;

            GoToAboutCommand = new RelayCommand(GoToAbout);
            GoToCalendarCommand = new RelayCommand(GoToCalendar);
            GoToProfileCommand = new RelayCommand(GoToProfile);
            GoToPlaygroundCommand = new RelayCommand(GoToPlayground);
        }

        public RelayCommand GoToAboutCommand { get; }

        public RelayCommand GoToCalendarCommand { get; }

        public RelayCommand GoToProfileCommand { get; }

        public RelayCommand GoToPlaygroundCommand { get; }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { Set(ref _imageUrl, value); }
        }

        public override async Task OnViewInitializedAsync(Dictionary<string, string> navigationParameters)
        {
            var profile = await _authenticationService.GetProfileAsync(imageSize: 200);
            await Task.Delay(2000);
            ImageUrl = profile.ImageUrl;
        }

        private void GoToAbout()
        {
            _navigationService.NavigateToAbout();
        }

        private void GoToCalendar()
        {
            _navigationService.NavigateToCalendar();
        }

        private void GoToProfile()
        {
            _navigationService.NavigateToProfile();
        }

        private void GoToPlayground()
        {
            ////_navigationService.NavigateToPlayground();
        }
    }
}
