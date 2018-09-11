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
        private readonly ICarTimesApi carTimesApi;

        private List<CarTime> carTimes;
        private List<CarDayViewModel> carDays;
        private List<DateTime> supportedYears;
        private List<DateTime> allMonths;
        private DateTime selectedYear;
        private DateTime selectedMonth;

        public CalendarViewModel(ICarTimesApi carTimesApi)
        {
            this.carTimesApi = carTimesApi;
        }

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

        public DateTime SelectedYear
        {
            get
            {
                return selectedYear;
            }

            set
            {
                Set(ref selectedYear, value);
                CarDays = GetCarDays(new DateTime(selectedYear.Year, SelectedMonth.Month, DateTime.MinValue.Day));
            }
        }

        public DateTime SelectedMonth
        {
            get
            {
                return selectedMonth;
            }

            set
            {
                Set(ref selectedMonth, value);
                CarDays = GetCarDays(new DateTime(SelectedYear.Year, selectedMonth.Month, DateTime.MinValue.Day));
            }
        }

        public override async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            await Task.Delay(200);
            //await RetrieveCarTimesAsync();

            AllMonths = CalendarInfoProvider.GetAllMonths();
            SupportedYears = CalendarInfoProvider.GetYearsFromNowAndInFuture(3);
            CarDays = GetCarDays(DateTime.Now);
        }

        private List<CarDayViewModel> GetCarDays(DateTime selectedDate)
        {
            var daysInMonth = CalendarInfoProvider.GetDaysInMonth(selectedDate);
            var tempCarDays = new List<CarDayViewModel>();
            foreach (var day in daysInMonth)
            {
                tempCarDays.Add(new CarDayViewModel(day.DayOfWeek.ToString(), day, false, "StellaFiesta.Client.CoreStandard.Images.nepal.png"));
            }

            return tempCarDays;
        }

        private async Task RetrieveCarTimesAsync()
        {
            carTimes = await carTimesApi.GetCarTimesAsync();
        }
    }
}
