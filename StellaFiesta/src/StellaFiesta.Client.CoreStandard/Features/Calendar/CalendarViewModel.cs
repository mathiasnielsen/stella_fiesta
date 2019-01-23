using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class CalendarViewModel : BindableViewModelBase
    {
        private const int MinimumTaskTimeInMs = 1000;

        private readonly ICarTimesApi carTimesApi;
        private readonly INavigationService navigationService;

        private List<CarDayViewModel> carDays;
        private List<DateTime> supportedYears;
        private List<DateTime> allMonths;
        private List<CarBooking> bookings;

        public CalendarViewModel(
            ICarTimesApi carTimesApi,
            INavigationService navigationService)
        {
            this.carTimesApi = carTimesApi;
            this.navigationService = navigationService;

            MonthSelectedCommand = new RelayCommand<DateTime>(MonthSelected);
            BookingDateSelectedCommand = new RelayCommand<CarDayViewModel>(BookingDateSelected);
        }

        public RelayCommand<DateTime> MonthSelectedCommand { get; }

        public RelayCommand<CarDayViewModel> BookingDateSelectedCommand { get; }

        public List<CarDayViewModel> CarDays
        {
            get { return carDays; }
            set { Set(ref carDays, value); }
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

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            UpdateCarDays(DateTime.Now);

            AllMonths = CalendarInfoProvider.GetAllMonths();
            SupportedYears = CalendarInfoProvider.GetYearsFromNowAndInFuture(3);

            return base.OnViewInitialized(navigationParameters);
        }

        public override async Task OnLoadAsync()
        {
            using (LoadingManager.CreateLoadingScope())
            {
                // All bookings
                await Task.WhenAll(RetrieveCarTimesAsync(), Task.Delay(MinimumTaskTimeInMs));

                UpdateCarDays(DateTime.Now);
            }
        }

        private List<CarDayViewModel> GetDaysInMonth(DateTime selectedDate)
        {
            var daysInMonth = CalendarInfoProvider.GetDaysInMonth(selectedDate);
            var tempCarDays = new List<CarDayViewModel>();
            var currentDate = DateTime.Now.Date;
            foreach (var day in daysInMonth)
            {
                tempCarDays.Add(
                    new CarDayViewModel(
                        day.DayOfWeek.ToString(),
                        day,
                        isBooked: false,
                        imageUrl: "StellaFiesta.Client.CoreStandard.Images.nepal.png"));
            }

            return tempCarDays;
        }

        private async Task RetrieveCarTimesAsync()
        {
            bookings = await carTimesApi.GetCarTimesAsync();
        }

        private void BookingDateSelected(CarDayViewModel bookingOrDayToBook)
        {
            if (bookingOrDayToBook.IsBooked)
            {
                var booking = bookings.FirstOrDefault(x => x.ID == bookingOrDayToBook.BookingId);
                navigationService.NavigateToBookingDetails(booking);
            }
            else
            {
                navigationService.NavigateToBooking(bookingOrDayToBook.Day);
            }
        }

        private void MonthSelected(DateTime dateInMonth)
        {
            UpdateCarDays(dateInMonth);
        }

        private void UpdateCarDays(DateTime date)
        {
            var daysInMonth = GetDaysInMonth(date);
            foreach (var dayInMonth in daysInMonth)
            {
                var potentialBooking = bookings?.FirstOrDefault(booking =>
                {
                    if (booking.BookingStartDate == null || booking.BookingEndDate == null)
                    {
                        return false;
                    }

                    var isCarDayBetweenBooking = booking.BookingStartDate <= dayInMonth.Day && booking.BookingEndDate >= dayInMonth.Day;
                    if (isCarDayBetweenBooking)
                    {
                    }

                    return isCarDayBetweenBooking;
                });

                if (potentialBooking != null)
                {
                    dayInMonth.IsBooked = true;
                    dayInMonth.BookingId = potentialBooking.ID;
                }
                else
                {
                    dayInMonth.IsBooked = false;
                    dayInMonth.BookingId = 0;
                }
            }

            CarDays = daysInMonth;
        }
    }
}
