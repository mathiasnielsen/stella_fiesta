using System;
using System.Collections.Generic;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

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
