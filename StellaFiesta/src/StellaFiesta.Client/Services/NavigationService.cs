using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard;
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
            Configure(nameof(BookingView), typeof(BookingView));
            Configure(nameof(BookingDetailsView), typeof(BookingDetailsView));
            Configure(nameof(SignInView), typeof(SignInView));
            Configure(nameof(ProfileView), typeof(ProfileView));
            Configure(nameof(PlaygroundView), typeof(PlaygroundView));
        }

        public void NavigateToHome()
        {
            NavigateTo(nameof(HomeView), historyBehavior: HistoryBehavior.ClearHistory);
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
            NavigateTo(nameof(SignInView), historyBehavior: HistoryBehavior.ClearHistory);
        }

        public void NavigateToProfile()
        {
            NavigateTo(nameof(ProfileView));
        }

        public void NavigateToPlayground()
        {
            NavigateTo(nameof(PlaygroundView));
        }

        public void NavigateToBooking(DateTime dateTime)
        {
            var dateTimeAsTicks = dateTime.Ticks.ToString();
            var parms = new Dictionary<string, string>()
            {
                {  MakeBookingViewModel.BookingDateInTicksParameterKey, dateTimeAsTicks }
            };

            NavigateTo(nameof(BookingView), parms);
        }

        public void NavigateToBookingDetails(CarBooking carBooking)
        {
            var carBookingAsJson = JsonConvert.SerializeObject(carBooking);
            var parms = new Dictionary<string, string>()
            {
                {  BookingDetailsViewModel.BookingParameterKey, carBookingAsJson }
            };

            NavigateTo(nameof(BookingDetailsView), parms);
        }
    }
}
