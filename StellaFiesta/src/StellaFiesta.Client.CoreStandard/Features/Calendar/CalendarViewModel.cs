﻿using System;
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

        private List<CarDayViewModel> carDays;
        private List<DateTime> supportedYears;
        private List<DateTime> allMonths;
        private List<CarBooking> carBookings;

        public CalendarViewModel(ICarTimesApi carTimesApi)
        {
            this.carTimesApi = carTimesApi;

            DateSelectedCommand = new RelayCommand<DateTime>(DateSelected);
        }

        public RelayCommand<DateTime> DateSelectedCommand { get; }

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

        public override async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            using (LoadingManager.CreateLoadingScope())
            {
                UpdateCarDays(DateTime.Now);

                await Task.Delay(4000);

                // All bookings
                await RetrieveCarTimesAsync();

                AllMonths = CalendarInfoProvider.GetAllMonths();
                SupportedYears = CalendarInfoProvider.GetYearsFromNowAndInFuture(3);

                UpdateCarDays(DateTime.Now);   
            }
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
            carBookings = await carTimesApi.GetCarTimesAsync();
        }

        private void DateSelected(DateTime date)
        {
            UpdateCarDays(date);
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