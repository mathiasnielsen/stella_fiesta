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

        private List<BookingDayViewModel> _bookingDaysInMonth;
        private List<CarBooking> _bookings;
        private DateTime _currentDisplayedDate;
        private bool _didGetBookings;
        private CancellationTokenSource _cancellationTokenSource;

        public CalendarViewModel(
            IBookingApi bookingApi,
            INavigationService navigationService,
            IToastService toastService,
            IConnectivityService connectivityService)
            : base(connectivityService)
        {
            this.bookingApi = bookingApi;
            this.navigationService = navigationService;
            this.toastService = toastService;

            MonthSelectedCommand = new RelayCommand<DateTime>(DateSelected);
            BookingDateSelectedCommand = new RelayCommand<BookingDayViewModel>(BookingDateSelected);

            CurrentDisplayedDate = DateTime.Now;
            BookingDaysInMonth = GetDaysInMonth(CurrentDisplayedDate);
        }

        public RelayCommand<DateTime> MonthSelectedCommand { get; }

        public RelayCommand<BookingDayViewModel> BookingDateSelectedCommand { get; }

        public List<BookingDayViewModel> BookingDaysInMonth
        {
            get { return _bookingDaysInMonth; }
            set { Set(ref _bookingDaysInMonth, value); }
        }

        public DateTime CurrentDisplayedDate
        {
            get { return _currentDisplayedDate; }
            set { Set(ref _currentDisplayedDate, value); }
        }

        public bool DidGetBookings
        {
            get { return _didGetBookings; }
            set { Set(ref _didGetBookings, value); }
        }

        public override async Task OnLoadAsync()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            using (LoadingManager.CreateLoadingScope())
            {
                // All bookings
                await Task.WhenAll(RetrieveCarTimesAsync(), Task.Delay(MinimumTaskTimeInMs));
                UpdateBookingDaysInMonthOfDay(BookingDaysInMonth);
            }
        }

        public override Task OnUnloadAsync()
        {
            _cancellationTokenSource?.Cancel();
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
            var bookingsResult = await bookingApi.GetBookingsAsync(_cancellationTokenSource.Token);
            DidGetBookings = bookingsResult.IsSuccess;
            if (DidGetBookings)
            {
                _bookings = bookingsResult.Data;
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
                var booking = _bookings.FirstOrDefault(x => x.BookingStartDate == bookingOrDayToBook.Day);
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
            BookingDaysInMonth = GetDaysInMonth(CurrentDisplayedDate);
            UpdateBookingDaysInMonthOfDay(BookingDaysInMonth);
        }

        private void UpdateBookingDaysInMonthOfDay(List<BookingDayViewModel> daysInMonth)
        {
            foreach (var dayInMonth in daysInMonth)
            {
                var booking = _bookings?.FirstOrDefault(x => x.BookingStartDate == dayInMonth.Day);
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
        }
    }
}
