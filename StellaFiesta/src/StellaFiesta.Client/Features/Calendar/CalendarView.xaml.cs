using System;
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

            custom_date_picker.MinimumDate = DateTime.Now;
            custom_date_picker.MaximumDate = DateTime.Now.AddYears(3);

            custom_date_picker.FinishedSelection += OnMonthSelected;
            date_list.ItemTapped += OnItemTapped;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            custom_date_picker.FinishedSelection -= OnMonthSelected;
            date_list.ItemTapped -= OnItemTapped;
        }

        private void OnMonthSelected(object sender, DateTime e)
        {
            ViewModel.MonthSelectedCommand.Execute(e);
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (CarDayViewModel)e.Item;
            ViewModel.BookingDateSelectedCommand.Execute(item);
        }
    }
}
