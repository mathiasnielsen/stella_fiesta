using System;
using StellaFiesta.Client.Core;
using Unity;

namespace StellaFiesta.Client
{
    public class BindableViewBase<TViewModel> : ViewBase
        where TViewModel : BindableViewModelBase
    {
        private bool hasAppeared;

        public BindableViewBase()
        {
            PrepareViewModelIfNeeded();
        }

        public TViewModel ViewModel { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.SubscripeBaseEvents();
            IntializeViewIfNeeded();

            ViewModel.ViewLoading();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.UnsubscripeBaseEvents();
            ViewModel.ViewUnloading();
        }

        private void PrepareViewModelIfNeeded()
        {
            if (ViewModel == null)
            {
                ViewModel = App.Container.Resolve<TViewModel>();
                BindingContext = ViewModel;
            }
        }

        private void IntializeViewIfNeeded()
        {
            if (hasAppeared == false)
            {
                InitializeViewBaseBindings();
                ViewModel.ViewInitialized(this.GetNavigationArgs());
                hasAppeared = true;
            }
        }

        private void InitializeViewBaseBindings()
        {
            // None yet.
        }
    }
}
