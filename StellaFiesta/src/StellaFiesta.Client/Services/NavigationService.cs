using System;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.Features.Common;

namespace StellaFiesta.Client
{
    public class NavigationService : NavigationBase, INavigationService
    {
        public NavigationService()
        {
            Configure(nameof(HomeView), typeof(HomeView));
            Configure(nameof(AboutView), typeof(AboutView));
        }

        public void NavigateToHome()
        {
            NavigateTo(nameof(HomeView));
        }

        public void NavigateToAbout()
        {
            NavigateTo(nameof(AboutView));
        }

        ////public void NavigateToDataMagazine(string directory = null)
        ////{
        ////    if (directory == null)
        ////    {
        ////        NavigateTo(nameof(DataMagazineView));
        ////    }
        ////    else
        ////    {
        ////        var parms = new Dictionary<string, string>();
        ////        parms.Add(DataMagazineViewModel.RelativeDirectoryParameterKey, directory);

        ////        NavigateTo(nameof(DataMagazineView), parameter: parms);
        ////    }
        ////}
    }
}
