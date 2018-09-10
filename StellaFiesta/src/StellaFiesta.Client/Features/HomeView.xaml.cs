using System;
using System.Collections.Generic;
using StellaFiesta.Client.Core;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Common
{
    public abstract class HomeViewBase : BindableViewBase<HomeViewModel>
    {
    }

    public partial class HomeView : HomeViewBase
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
