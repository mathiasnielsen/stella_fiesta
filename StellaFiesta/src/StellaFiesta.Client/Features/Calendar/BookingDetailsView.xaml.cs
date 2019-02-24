using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Features.Calendar
{
    public abstract class BookingDetailsViewBase : BindableViewBase<BookingDetailsViewModel>
    {
    }

    public partial class BookingDetailsView : BookingDetailsViewBase
    {
        public BookingDetailsView()
        {
            InitializeComponent();
        }
    }
}
