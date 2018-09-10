using System;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client
{
    public class NavigationService : NavigationBase, INavigationService
    {
        public NavigationService()
        {
            Configure(nameof(HomeView), typeof(HomeView));
        }

        public void NavigateToHome()
        {
            NavigateTo(nameof(HomeView));
        }

        public void NavigateToDataMagazine(string directory = null)
        {
            if (directory == null)
            {
                NavigateTo(nameof(DataMagazineView));
            }
            else
            {
                var parms = new Dictionary<string, string>();
                parms.Add(DataMagazineViewModel.RelativeDirectoryParameterKey, directory);

                NavigateTo(nameof(DataMagazineView), parameter: parms);
            }
        }
    }
}
