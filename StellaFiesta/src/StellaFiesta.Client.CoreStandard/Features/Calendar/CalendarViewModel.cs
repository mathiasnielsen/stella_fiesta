using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class CalendarViewModel : BindableViewModelBase
    {
        private const int MinimumTaskTimeInMs = 1000;

        private readonly IBookingApi bookingApi;
        private readonly INavigationService navigationService;
        private readonly IToastService toastService;

        private List<BookingDayViewModel> bookingDaysInMonth;
        private List<DateTime> supportedYears;
        private List<DateTime> allMonths;
        private List<CarBooking> bookings;
        private DateTime currentDisplayedDate;
        private bool didGetBookings;
        private CancellationTokenSource cancellationTokenSource;

        public CalendarViewModel(
            IBookingApi bookingApi,
            INavigationService navigationService,
            IToastService toastService,
            IConnectivityService connectivityService)
            : base (connectivityService)
        {
            this.bookingApi = bookingApi;
            this.navigationService = navigationService;
            this.toastService = toastService;

            MonthSelectedCommand = new RelayCommand<DateTime>(DateSelected);
            BookingDateSelectedCommand = new RelayCommand<BookingDayViewModel>(BookingDateSelected);
        }

        public RelayCommand<DateTime> MonthSelectedCommand { get; }

        public RelayCommand<BookingDayViewModel> BookingDateSelectedCommand { get; }

        public List<BookingDayViewModel> BookingDaysInMonth
        {
            get { return bookingDaysInMonth; }
            set { Set(ref bookingDaysInMonth, value); }
        }

        public List<DateTime> SupportedYears
        {
            get { return supportedYears; }
            set { Set(ref supportedYears, value); }
        }

        public List<DateTime> AllMonths
        {
            get { return allMonths; }
            set { Set(ref allMonths, value); }
        }

        public DateTime CurrentDisplayedDate
        {
            get { return currentDisplayedDate; }
            set { Set(ref currentDisplayedDate, value); }
        }

        public bool DidGetBookings
        {
            get { return didGetBookings; }
            set { Set(ref didGetBookings, value); }
        }

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            CurrentDisplayedDate = DateTime.Now;
            UpdateBookingDaysInMonthOfDay(CurrentDisplayedDate);

            AllMonths = CalendarInfoProvider.GetAllMonths();
            SupportedYears = CalendarInfoProvider.GetYearsFromNowAndInFuture(3);

            return base.OnViewInitialized(navigationParameters);
        }

        public override async Task OnLoadAsync()
        {
            cancellationTokenSource = new CancellationTokenSource();
            using (LoadingManager.CreateLoadingScope())
            {
                // All bookings
                await Task.WhenAll(RetrieveCarTimesAsync(), Task.Delay(MinimumTaskTimeInMs));
                UpdateBookingDaysInMonthOfDay(CurrentDisplayedDate);
            }
        }

        public override Task OnUnloadAsync()
        {
            cancellationTokenSource.Cancel();
            return base.OnUnloadAsync();
        }

        protected override void OnIsConnectedChanged(bool isConnected)
        {
            IsShowingOfflineState = isConnected;
        }

        private List<BookingDayViewModel> GetDaysInMonth(DateTime selectedDate)
        {
            var daysInMonth = CalendarInfoProvider.GetDaysInMonth(selectedDate);
            var tempBookingDays = new List<BookingDayViewModel>();
            var currentDate = DateTime.Now.Date;
            foreach (var day in daysInMonth)
            {
                tempBookingDays.Add(
                    new BookingDayViewModel(
                        day.DayOfWeek.ToString(),
                        day,
                        isBooked: false,
                        imageUrl: "StellaFiesta.Client.CoreStandard.Images.nepal.png"));
            }

            return tempBookingDays;
        }

        private async Task RetrieveCarTimesAsync()
        {
            var bookingsResult = await bookingApi.GetBookingsAsync(cancellationTokenSource.Token);
            DidGetBookings = bookingsResult.IsSuccess;
            if (DidGetBookings)
            {
                bookings = bookingsResult.Data;
            }
            else
            {
                toastService.LongAlert("Failed to retrieve current bookings");
            }
        }

        private void BookingDateSelected(BookingDayViewModel bookingOrDayToBook)
        {
            if (bookingOrDayToBook.IsBooked)
            {
                var booking = bookings.FirstOrDefault(x => x.BookingStartDate == bookingOrDayToBook.Day);
                navigationService.NavigateToBookingDetails(booking);
            }
            else
            {
                navigationService.NavigateToBooking(bookingOrDayToBook.Day);
            }
        }

        private void DateSelected(DateTime date)
        {
            CurrentDisplayedDate = date;
            UpdateBookingDaysInMonthOfDay(CurrentDisplayedDate);
        }

        private void UpdateBookingDaysInMonthOfDay(DateTime date)
        {
            var daysInMonth = GetDaysInMonth(date);
            foreach (var dayInMonth in daysInMonth)
            {
                var booking = bookings?.FirstOrDefault(x => x.BookingStartDate == dayInMonth.Day);
                if (booking != null)
                {
                    dayInMonth.IsBooked = true;
                    dayInMonth.BookingId = booking.ID;
                }
                else
                {
                    dayInMonth.IsBooked = false;
                    dayInMonth.BookingId = 0;
                }
            }

            BookingDaysInMonth = daysInMonth;
        }
    }
}
