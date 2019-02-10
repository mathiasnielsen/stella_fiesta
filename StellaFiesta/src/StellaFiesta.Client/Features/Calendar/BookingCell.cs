using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client.Features.Calendar
{
    public class BookingCell : ViewCell
    {
        private BookingDayViewModel _itemViewModel;

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var hadPreviousViewModel = _itemViewModel != null;
            if (hadPreviousViewModel)
            {
                // Unhook
            }

            _itemViewModel = BindingContext as BookingDayViewModel;
            if (_itemViewModel != null)
            {
                // Hook up
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ////FadeControl(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ////FadeControl(false);
        }

        private async void FadeControl(bool toBecomeVisible)
        {
            View.AbortAnimation("FadeTo");
            if (toBecomeVisible)
            {
                View.IsVisible = true;
                View.Opacity = 0.0;
                var isCancelled = await View.FadeTo(1.0, AnimationHelper.ControlFadeInDurationInMs);
                System.Diagnostics.Debug.WriteLine($"Did fadein cancel: {isCancelled}");
            }
            else
            {
                var isCancelled = await View.FadeTo(0.0, AnimationHelper.ControlFadeOutDurationInMs);
                System.Diagnostics.Debug.WriteLine($"Did fadeout cancel: {isCancelled}");
                View.IsVisible = false;
            }
        }
    }
}
