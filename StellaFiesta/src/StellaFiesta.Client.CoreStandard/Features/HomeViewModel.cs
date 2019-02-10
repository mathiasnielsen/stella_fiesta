using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class HomeViewModel : BindableViewModelBase
    {
        private readonly INavigationService navigationService;

        public HomeViewModel(
            IConnectivityService connectivityService,
            INavigationService navigationService)
            : base (connectivityService)
        {
            this.navigationService = navigationService;

            GoToAboutCommand = new RelayCommand(GoToAbout);
            GoToCalendarCommand = new RelayCommand(GoToCalendar);
            GoToProfileCommand = new RelayCommand(GoToProfile);
            GoToPlaygroundCommand = new RelayCommand(GoToPlayground);
        }

        public RelayCommand GoToAboutCommand { get; }

        public RelayCommand GoToCalendarCommand { get; }

        public RelayCommand GoToProfileCommand { get; }

        public RelayCommand GoToPlaygroundCommand { get; }

        private void GoToAbout()
        {
            navigationService.NavigateToAbout();
        }

        private void GoToCalendar()
        {
            navigationService.NavigateToCalendar();
        }

        private void GoToProfile()
        {
            navigationService.NavigateToProfile();
        }

        private void GoToPlayground()
        {
            navigationService.NavigateToPlayground();
        }
    }
}
