using System;
using GalaSoft.MvvmLight.Command;

namespace StellaFiesta.Client.Core
{
    public class HomeViewModel : BindableViewModelBase
    {
        private readonly INavigationService navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GoToAboutCommand = new RelayCommand(GoToAbout);
        }

        public RelayCommand GoToAboutCommand { get; }

        private void GoToAbout()
        {
            navigationService.NavigateToAbout();
        }
    }
}
