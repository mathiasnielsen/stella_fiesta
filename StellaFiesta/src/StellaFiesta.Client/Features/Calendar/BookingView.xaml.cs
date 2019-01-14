using System;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Features.Calendar
{
    public abstract class BookingViewBase : BindableViewBase<BookingViewModel>
    {
    }

    public partial class BookingView : BookingViewBase
    {
        public BookingView()
        {
            InitializeComponent();
        }
    }
}
