using System;
using StellaFiesta.Api;

namespace StellaFiesta.Client.Core
{
    public interface INavigationService
    {
        void GoBack();

        void NavigateToHome();

        void NavigateToAbout();

        void NavigateToCalendar();

        void NavigateToSignIn();

        void NavigateToProfile();

        void NavigateToPlayground();

        void NavigateToBooking(DateTime dateTime);

        void NavigateToBookingDetails(CarBooking carBooking);
    }
}
