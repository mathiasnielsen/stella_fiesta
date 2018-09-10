using System;
namespace StellaFiesta.Client
{
    public class BindableViewBase<TViewModel> : ViewBase
    {
        public BindableViewBase()
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
