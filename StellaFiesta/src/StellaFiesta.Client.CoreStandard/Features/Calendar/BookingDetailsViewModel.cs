using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard.Utilities;

namespace StellaFiesta.Client.CoreStandard
{
    public class BookingDetailsViewModel : BindableViewModelBase
    {
        public const string BookingParameterKey = nameof(BookingParameterKey);

        private readonly ICarTimesApi carTimesApi;
        private readonly INavigationService navigationService;
        private readonly IAuthenticationService authenticationService;
        private readonly IDialogService dialogService;
        private readonly IToastService toastService;

        private CarBooking booking;
        private string dateTitle;
        private bool isBooker;

        public BookingDetailsViewModel(
            INavigationService navigationService,
            ICarTimesApi carTimesApi,
            IAuthenticationService authenticationService,
            IDialogService dialogService,
            IToastService toastService)
        {
            this.navigationService = navigationService;
            this.carTimesApi = carTimesApi;
            this.authenticationService = authenticationService;
            this.dialogService = dialogService;
            this.toastService = toastService;

            CancelBookingCommand = new RelayCommand(CancelBooking);
        }

        public RelayCommand CancelBookingCommand { get; }

        public string DateTitle
        {
            get { return dateTitle; }
            set { Set(ref dateTitle, value); }
        }

        public bool IsBooker
        {
            get { return isBooker; }
            set { Set(ref isBooker, value); }
        }

        public override async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            booking = NavigationParameterParser.JsonConvertParameter<CarBooking>(
                navigationParameters[BookingParameterKey]);

            var bookingTitle = DateTimeToStringHelper.GetTitleFromDate(booking.BookingStartDate);
            DateTitle = $"{bookingTitle}{System.Environment.NewLine}by {booking.BookerName}";

            var user = await authenticationService.GetProfileAsync();
            IsBooker = booking.BookerId == user.UserId;
        }

        private async void CancelBooking()
        {
            var didAccept = await dialogService.ShowMessageAsync("Warning!", "Do you want to cancel your booking?", "cancel", "cancel booking");
            if (didAccept)
            {
                using (LoadingManager.CreateLoadingScope())
                {
                    var user = await authenticationService.GetProfileAsync();
                    var didRemove = await carTimesApi.RemoveBookingAsync(booking.ID);
                    if (didRemove)
                    {
                        toastService.ShortAlert("Booking as been cancelled");
                    }
                    else
                    {
                        toastService.ShortAlert("Failed to cancel the booking");
                    }
                }
            }
        }
    }
}
