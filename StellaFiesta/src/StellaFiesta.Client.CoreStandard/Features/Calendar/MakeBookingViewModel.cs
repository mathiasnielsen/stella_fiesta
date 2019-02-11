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

        private readonly IBookingApi _bookingApi;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IToastService _toastService;

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
            _navigationService = navigationService;
            _bookingApi = carTimesApi;
            _authenticationService = authenticationService;
            _toastService = toastService;

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

        public override Task OnLoadAsync()
        {
            IsShowingOfflineState = IsConnected == false;
            return base.OnLoadAsync();
        }

        protected override void OnIsConnectedChanged(bool isConnected)
        {
            IsShowingOfflineState = isConnected == false;
        }

        private async void MakeBooking()
        {
            using (LoadingManager.CreateLoadingScope())
            {
                var user = await _authenticationService.GetProfileAsync();
                var carBooking = new CarBooking()
                {
                    BookerName = user.Name,
                    BookerId = user.UserId,
                    BookingStartDate = bookingDate,
                    BookingEndDate = bookingDate.AddDays(1),
                };

                var didMakeBooking = await _bookingApi.MakingBookingAsync(carBooking);
                if (didMakeBooking)
                {
                    _toastService.ShortAlert("Booking as been made");
                    _navigationService.GoBack();
                }
                else
                {
                    _toastService.ShortAlert("Failed to make the booking");
                }
            }
        }
    }
}
