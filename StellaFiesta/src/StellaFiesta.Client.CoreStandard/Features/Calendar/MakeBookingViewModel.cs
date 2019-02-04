using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard.Utilities;

namespace StellaFiesta.Client.CoreStandard
{
    public class MakeBookingViewModel : BindableViewModelBase
    {
        public const string BookingDateInTicksParameterKey = nameof(BookingDateInTicksParameterKey);

        private readonly ICarTimesApi carTimesApi;
        private readonly INavigationService navigationService;
        private readonly IAuthenticationService authenticationService;
        private readonly IToastService toastService;

        private DateTime bookingDate;
        private string dateTitle;

        public MakeBookingViewModel(
            INavigationService navigationService,
            ICarTimesApi carTimesApi,
            IAuthenticationService authenticationService,
            IToastService toastService)
        {
            this.navigationService = navigationService;
            this.carTimesApi = carTimesApi;
            this.authenticationService = authenticationService;
            this.toastService = toastService;

            MakeBookingCommand = new RelayCommand(MakeBooking);
        }

        public RelayCommand MakeBookingCommand { get; }

        public string DateTitle
        {
            get { return dateTitle; }
            set { Set(ref dateTitle, value); }
        }

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            bookingDate = NavigationParameterParser.StringDateTicksToDateTime(
                 navigationParameters[BookingDateInTicksParameterKey]);

            DateTitle = DateTimeToStringHelper.GetTitleFromDate(bookingDate);

            return base.OnViewInitialized(navigationParameters);
        }

        private async void MakeBooking()
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

                var didMakeBooking = await carTimesApi.MakingBookingAsync(carBooking);
                if (didMakeBooking)
                {
                    toastService.ShortAlert("Booking as been made");
                }
                else
                {
                    toastService.ShortAlert("Failed to make the booking");
                }
            }
        }
    }
}
