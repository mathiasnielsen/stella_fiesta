using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard.Utilities;

namespace StellaFiesta.Client.CoreStandard
{
    public class BookingViewModel : BindableViewModelBase
    {
        public const string BookingDateInTicksParameterKey = nameof(BookingDateInTicksParameterKey);

        private readonly ICarTimesApi carTimesApi;
        private readonly INavigationService navigationService;
        private readonly IAuthenticationService authenticationService;

        private DateTime bookingDate;
        private string dateTitle;

        public BookingViewModel(
            INavigationService navigationService,
            ICarTimesApi carTimesApi,
            IAuthenticationService authenticationService)
        {
            this.navigationService = navigationService;
            this.carTimesApi = carTimesApi;
            this.authenticationService = authenticationService;

            AcceptBookingCommand = new RelayCommand(AcceptBooking);
        }

        public RelayCommand AcceptBookingCommand { get; }

        public string DateTitle
        {
            get { return dateTitle; }
            set { Set(ref dateTitle, value); }
        }

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            bookingDate = NavigationParameterParser.StringDateTicksToDateTime(
                 navigationParameters[BookingDateInTicksParameterKey]);

            DateTitle = GetDateInText(bookingDate);

            return base.OnViewInitialized(navigationParameters);
        }

        private string GetDateInText(DateTime dateTime)
        {
            var day = dateTime.GetDayNumberInMonth();
            var weekdayName = dateTime.GetWeekdayName();
            var month = dateTime.GetMonthName();
            var year = dateTime.GetYear();

            return $"{day} ({weekdayName}), {month}, {year}";
        }

        private async void AcceptBooking()
        {
            using (LoadingManager.CreateLoadingScope())
            {
                var user = await authenticationService.GetProfileAsync();
                var carBooking = new CarBooking()
                {
                    BookerName = user.Name,
                    BookingStartDate = bookingDate,
                    BookingEndDate = bookingDate.AddDays(1),
                };

                await carTimesApi.SendBookingAsync(carBooking);
            }
        }
    }
}
