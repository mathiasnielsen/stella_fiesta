using System;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public static class AnimationHelper
    {
        public const int ControlFadeInDurationInMs = 200;
        public const int ControlFadeOutDurationInMs = 200;

        public async static void FadeControl(ContentView control, bool toBecomeVisible)
        {
            if (toBecomeVisible)
            {
                control.IsVisible = true;
                control.Opacity = 0.0;
                var isCancelled = await control.FadeTo(1.0, AnimationHelper.ControlFadeInDurationInMs);
            }
            else
            {
                var isCancelled = await control.FadeTo(0.0, AnimationHelper.ControlFadeOutDurationInMs);
                control.IsVisible = false;
            }
        }
    }
}
