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

        private readonly IBookingApi carTimesApi;
        private readonly INavigationService navigationService;
        private readonly IAuthenticationService authenticationService;
        private readonly IToastService toastService;

        private DateTime bookingDate;
        private string dateTitle;

        public MakeBookingViewModel(
            IConnectivityService connectivityService,
            INavigationService navigationService,
            IBookingApi carTimesApi,
            IAuthenticationService authenticationService,
            IToastService toastService)
            : base(connectivityService)
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

        public override Task OnViewInitializedAsync(Dictionary<string, string> navigationParameters)
        {
            bookingDate = NavigationParameterParser.StringDateTicksToDateTime(
                 navigationParameters[BookingDateInTicksParameterKey]);

            DateTitle = DateTimeToStringHelper.GetTitleFromDate(bookingDate);

            return base.OnViewInitializedAsync(navigationParameters);
        }

        private async void MakeBooking()
        {
            using (LoadingManager.CreateLoadingScope())
            {
                var user = await authenticationService.GetProfileAsync();
                var carBooking = new CarBooking()
                {
                    BookerName = user.Name,
                    BookerId = user.UserId,
                    BookingStartDate = bookingDate,
                    BookingEndDate = bookingDate.AddDays(1),
                };

                var didMakeBooking = await carTimesApi.MakingBookingAsync(carBooking);
                if (didMakeBooking)
                {
                    toastService.ShortAlert("Booking as been made");
                    navigationService.GoBack();
                }
                else
                {
                    toastService.ShortAlert("Failed to make the booking");
                }
            }
        }
    }
}
