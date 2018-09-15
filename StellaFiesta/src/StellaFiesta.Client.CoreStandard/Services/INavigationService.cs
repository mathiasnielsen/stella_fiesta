using System;
namespace StellaFiesta.Client.Core
{
    public interface INavigationService
    {
        void NavigateToAbout();

        void NavigateToCalendar();

        void NavigateToSignIn();
    }
}
