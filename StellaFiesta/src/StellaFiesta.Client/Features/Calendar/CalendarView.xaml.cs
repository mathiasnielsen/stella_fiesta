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

        private void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
        }
    }
}
