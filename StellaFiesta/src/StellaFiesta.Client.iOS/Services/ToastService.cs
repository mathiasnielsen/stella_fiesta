using Foundation;
using StellaFiesta.Client.CoreStandard;
using UIKit;

namespace StellaFiesta.Client.iOS
{
    public class ToastService : IToastService
    {
        const double LongMessageDurationInSec = 3.5;
        const double ShortMessageDurationInSec = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public void LongAlert(string message)
        {
            ShowAlert(message, LongMessageDurationInSec);
        }
        public void ShortAlert(string message)
        {
            ShowAlert(message, ShortMessageDurationInSec);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                DismissMessage();
            });

            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        private void DismissMessage()
        {
            alert?.DismissViewController(true, null);
            alertDelay?.Dispose();
        }
    }
}
