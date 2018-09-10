using System;
namespace StellaFiesta.Client.Core
{
    public class HomeViewModel : BindableViewModelBase
    {
        private readonly INavigationService navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public RelayCommand GoToAboutCommand { get; }
    }
}
