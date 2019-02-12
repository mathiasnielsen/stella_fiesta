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

        private readonly IBookingApi _bookingApi;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDialogService _dialogService;
        private readonly IToastService _toastService;

        private CarBooking booking;
        private string dateTitle;
        private bool isBooker;

        public BookingDetailsViewModel(
            IConnectivityService connectivityService,
            INavigationService navigationService,
            IBookingApi carTimesApi,
            IAuthenticationService authenticationService,
            IDialogService dialogService,
            IToastService toastService)
            : base(connectivityService)
        {
            _navigationService = navigationService;
            _bookingApi = carTimesApi;
            _authenticationService = authenticationService;
            _dialogService = dialogService;
            _toastService = toastService;

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

        public override async Task OnViewInitializedAsync(Dictionary<string, string> navigationParameters)
        {
            booking = NavigationParameterParser.JsonConvertParameter<CarBooking>(
                navigationParameters[BookingParameterKey]);

            var bookingTitle = DateTimeToStringHelper.GetTitleFromDate(booking.BookingStartDate);
            DateTitle = $"{bookingTitle}{System.Environment.NewLine}by {booking.BookerName}";

            var user = await _authenticationService.GetProfileAsync();
            IsBooker = booking.BookerId == user.UserId;
        }

        public override Task OnLoadAsync()
        {
            IsShowingOfflineState = IsConnected == false;
            return base.OnLoadAsync();
        }

        protected override void OnIsConnectedChanged(bool isConnected)
        {
            IsShowingOfflineState = isConnected == false;
        }

        private async void CancelBooking()
        {
            var didAccept = await _dialogService.ShowMessageAsync("Warning!", "Do you want to cancel your booking?", "cancel", "cancel booking");
            if (didAccept)
            {
                using (LoadingManager.CreateLoadingScope())
                {
                    var user = await _authenticationService.GetProfileAsync();
                    var didRemove = await _bookingApi.RemoveBookingAsync(booking.ID);
                    if (didRemove)
                    {
                        _toastService.ShortAlert("Booking as been cancelled");
                        _navigationService.GoBack();
                    }
                    else
                    {
                        _toastService.ShortAlert("Failed to cancel the booking");
                    }
                }
            }
        }
    }
}
