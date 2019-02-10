using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Calendar
{
    public class BookingCell : ViewCell
    {
        private BookingDayViewModel _viewModel;

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (_viewModel != null)
            {
            }

            _viewModel = BindingContext as BookingDayViewModel;

            if (_viewModel != null)
            {
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FadeControl(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            FadeControl(false);
        }

        private async void FadeControl(bool toBecomeVisible)
        {
            if (toBecomeVisible)
            {
                View.IsVisible = true;
                View.Opacity = 0.0;
                var isCancelled = await View.FadeTo(1.0, AnimationHelper.ControlFadeInDurationInMs);
            }
            else
            {
                var isCancelled = await View.FadeTo(0.0, AnimationHelper.ControlFadeOutDurationInMs);
                View.IsVisible = false;
            }
        }
    }
}
