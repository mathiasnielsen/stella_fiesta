using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard.Services;
using StellaFiesta.Client.CoreStandard.Utilities;

namespace StellaFiesta.Client.CoreStandard
{
    public class MakeBookingViewModel : BindableViewModelBase
    {
        public const string BookingDateInTicksParameterKey = nameof(BookingDateInTicksParameterKey);
        private const int ReminderNotificationId = 1001;

        private readonly IBookingApi _bookingApi;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IToastService _toastService;
        private readonly ILocalNotificationService _localNotificationService;

        private DateTime bookingDate;
        private string dateTitle;

        public MakeBookingViewModel(
            IConnectivityService connectivityService,
            INavigationService navigationService,
            IBookingApi carTimesApi,
            IAuthenticationService authenticationService,
            IToastService toastService,
            ILocalNotificationService localNotificationService)
            : base(connectivityService)
        {
            _navigationService = navigationService;
            _bookingApi = carTimesApi;
            _authenticationService = authenticationService;
            _toastService = toastService;
            _localNotificationService = localNotificationService;

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
                    ScheduleReminder();
                    _navigationService.GoBack();
                }
                else
                {
                    _toastService.ShortAlert("Failed to make the booking");
                }
            }
        }

        private void ScheduleReminder()
        {
            var title = "Returning Stella";
            var body = "Remember to return Stella before 12.00";
            var timeStampForReminder = DateTime.Now.AddSeconds(10);

            _localNotificationService.ScheduleNotification(title, body, ReminderNotificationId, timeStampForReminder);
        }
    }
}
