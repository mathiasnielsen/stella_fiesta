using System;
using StellaFiesta.Client.CoreStandard;

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

            custom_date_picker.FinishedSelection += OnFinishedSelection;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            custom_date_picker.FinishedSelection -= OnFinishedSelection;
        }

        private void OnFinishedSelection(object sender, DateTime e)
        {
            ViewModel.DateSelectedCommand.Execute(e);
        }
    }
}
