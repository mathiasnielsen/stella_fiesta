using System;
using System.Collections.Generic;
using System.Linq;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Calendar
{
    public abstract class CalendarViewBase : BindableViewBase<CalendarViewModel>
    {
    }

    public partial class CalendarView : CalendarViewBase
    {
        public CalendarView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            date_picker.MinimumDate = DateTime.Now;
            date_picker.MaximumDate = DateTime.Now.AddYears(1);

            date_picker.DateSelected += OnDateSelected;
            date_list.ItemTapped += OnItemTapped;

            date_list.ItemAppearing += OnItemAppearing;
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            date_picker.DateSelected -= OnDateSelected;
            date_list.ItemTapped -= OnItemTapped;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            ViewModel.MonthSelectedCommand.Execute(e.NewDate);
            ScrollToSelectedDate(e.NewDate);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (BookingDayViewModel)e.Item;
            if (item.IsValidBookingDate)
            {
                ViewModel.BookingDateSelectedCommand.Execute(item);
            }
        }

        private void ScrollToSelectedDate(DateTime date)
        {
            if (date_list.ItemsSource is List<BookingDayViewModel> bookings)
            {
                var item = bookings.FirstOrDefault(x => x.Day.Day == date.Day);
                date_list.ScrollTo(item, ScrollToPosition.MakeVisible, true);
            }
        }
    }
}
