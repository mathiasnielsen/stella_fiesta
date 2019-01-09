using System;
using StellaFiesta.Client.Core;
using Unity;

namespace StellaFiesta.Client
{
    public class BindableViewBase<TViewModel> : ViewBase
        where TViewModel : BindableViewModelBase
    {
        private bool hasAppeared;

        public TViewModel ViewModel { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (hasAppeared == false)
            {
                ViewModel = OnPrepareViewModel();
                BindingContext = ViewModel;

                InitializeViewBaseBindings();
                ViewModel.ViewInitialized(this.GetNavigationArgs());
                hasAppeared = true;
            }

            ViewModel.ViewLoading();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.ViewUnloading();
        }

        protected virtual TViewModel OnPrepareViewModel()
        {
            return App.Container.Resolve<TViewModel>();
        }

        private void InitializeViewBaseBindings()
        {
            // None yet.
        }
    }
}
