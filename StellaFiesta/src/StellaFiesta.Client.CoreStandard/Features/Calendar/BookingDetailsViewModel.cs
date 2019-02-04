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

        private CarBooking booking;
        private string dateTitle;

        public BookingDetailsViewModel(
            INavigationService navigationService,
            ICarTimesApi carTimesApi,
            IAuthenticationService authenticationService,
            IDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.carTimesApi = carTimesApi;
            this.authenticationService = authenticationService;
            this.dialogService = dialogService;

            CancelBookingCommand = new RelayCommand(CancelBooking);
        }

        public RelayCommand CancelBookingCommand { get; }

        public string DateTitle
        {
            get { return dateTitle; }
            set { Set(ref dateTitle, value); }
        }

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            booking = NavigationParameterParser.JsonConvertParameter<CarBooking>(
                navigationParameters[BookingParameterKey]);

            var bookingTitle = DateTimeToStringHelper.GetTitleFromDate(booking.BookingStartDate);
            DateTitle = $"{bookingTitle}{System.Environment.NewLine}by {booking.BookerName}";

            return base.OnViewInitialized(navigationParameters);
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
                }
            }
        }
    }
}
