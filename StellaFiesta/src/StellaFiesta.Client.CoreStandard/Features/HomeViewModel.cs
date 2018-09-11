using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class HomeViewModel : BindableViewModelBase
    {
        private readonly INavigationService navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GoToAboutCommand = new RelayCommand(GoToAbout);
            GoToCalendarCommand = new RelayCommand(GoToCalendar);
        }

        public RelayCommand GoToAboutCommand { get; }

        public RelayCommand GoToCalendarCommand { get; }

        private void GoToAbout()
        {
            navigationService.NavigateToAbout();
        }

        private void GoToCalendar()
        {
            navigationService.NavigateToCalendar();
        }
    }
}
