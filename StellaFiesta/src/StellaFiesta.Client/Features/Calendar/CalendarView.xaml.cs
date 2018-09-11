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

            datepicker.MinimumDate = DateTime.Now;
            datepicker.MaximumDate = DateTime.Now.AddYears(1);
            datepicker.Date = ViewModel.StartDate;

            datepicker.DateSelected += OnDateSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            datepicker.DateSelected -= OnDateSelected;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            ViewModel.DateSelectedCommand.Execute(e.NewDate);
        }
    }
}
