using System;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.Features.Account;
using StellaFiesta.Client.Features.Calendar;
using StellaFiesta.Client.Features.Common;

namespace StellaFiesta.Client
{
    public class NavigationService : NavigationBase, INavigationService
    {
        public NavigationService()
        {
            Configure(nameof(HomeView), typeof(HomeView));
            Configure(nameof(AboutView), typeof(AboutView));
            Configure(nameof(CalendarView), typeof(CalendarView));
            Configure(nameof(SignInView), typeof(SignInView));
            Configure(nameof(FacebookLoginPage), typeof(FacebookLoginPage));
        }

        public void NavigateToHome()
        {
            NavigateTo(nameof(HomeView));
        }

        public void NavigateToAbout()
        {
            NavigateTo(nameof(AboutView));
        }

        public void NavigateToCalendar()
        {
            NavigateTo(nameof(CalendarView));
        }

        public void NavigateToSignIn()
        {
            ////NavigateTo(nameof(SignInView));
            NavigateTo(nameof(FacebookLoginPage));
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
