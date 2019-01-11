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
        private List<CarBooking> carBookings;

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

        private List<CarDayViewModel> GetCarDays(DateTime selectedDate)
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
            carBookings = await carTimesApi.GetCarTimesAsync();
        }

        private void BookingDateSelected(CarDayViewModel date)
        {
            navigationService.NavigateToBooking(date.Day);
        }

        private void MonthSelected(DateTime dateInMonth)
        {
            UpdateCarDays(dateInMonth);
        }

        private void UpdateCarDays(DateTime date)
        {
            var tempCarDays = GetCarDays(date);
            foreach (var carDay in tempCarDays)
            {
                var booking = carBookings?.FirstOrDefault(b =>
                {
                    if (b.BookingStartDate == null || b.BookingEndDate == null)
                    {
                        return false;
                    }

                    return
                        b.BookingStartDate.Value.Ticks < carDay.Day.Ticks
                        && b.BookingEndDate.Value.Ticks > carDay.Day.Ticks;
                });

                if (booking != null)
                {
                    carDay.IsBooked = true;
                }
            }

            CarDays = tempCarDays;
        }
    }
}
