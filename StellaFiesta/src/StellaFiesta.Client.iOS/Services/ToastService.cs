using CoreGraphics;
using Foundation;
using StellaFiesta.Client.CoreStandard;
using UIKit;
using Xamarin.Forms;

namespace StellaFiesta.Client.iOS
{
    public class ToastService : IToastService
    {
        private const float FadeInDuractionInSec = 0.15f;
        private const float FadeOutDuractionInSec = 0.3f;
        private const double LongMessageDurationInSec = 3.5;
        private const double ShortMessageDurationInSec = 2.0;

        private const int ToastHeight = 60;
        private const int ToastWidth = 180;
        private const int ToastPaddingSize = 8;

        private const float ToastCornerRadius = ToastPaddingSize;
        private const float ToastBorderWidth = 1.5f;
        private const int ToastBottomOffset = 48;
        private const float ShadowOpacity = 0.5f;
        private const float ShadowRadius = 1.0f;
        private const float ShadowOffset = 0.5f;

        private readonly UIWindow toastWindow;
        private readonly ToastViewController toastViewController;

        private UILabel messageLabel;

        public ToastService()
        {
            toastWindow = ConstructWindow();
            toastViewController = new ToastViewController();
            toastWindow.RootViewController = toastViewController;

            PrepareUIElements();
        }

        public void LongAlert(string message)
        {
            SetMessage(message);
            FadeInAndShow(LongMessageDurationInSec);
        }

        public void ShortAlert(string message)
        {
            SetMessage(message);
            FadeInAndShow(ShortMessageDurationInSec);
        }

        private UIWindow ConstructWindow()
        {
            var screenBounds = UIScreen.MainScreen.Bounds;

            var screenCenter = new CGPoint(screenBounds.Width / 2, screenBounds.Height / 2);
            var posY = screenBounds.Height - ToastHeight - ToastBottomOffset;
            var posX = screenCenter.X - (ToastWidth / 2);

            var windowBounds = new CGRect(posX, posY, ToastWidth, ToastHeight);

            return new UIWindow(windowBounds);
        }

        private void SetMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                messageLabel.Text = message;

                toastWindow.SetNeedsLayout();
                toastWindow.LayoutIfNeeded();
            });
        }

        private void FadeInAndShow(double durationInSec)
        {
            //animate by fading in
            toastWindow.Alpha = 0;

            toastWindow.WindowLevel = UIWindowLevel.Alert + 1;
            toastWindow.Hidden = false;

            UIView.Animate(
                duration: FadeInDuractionInSec,
                animation: () => toastWindow.Alpha = 1.0f,
                completion: () => InitiateTimer(durationInSec));
        }

        private void FadeOutAndHide()
        {
            UIView.Animate(
                duration: FadeOutDuractionInSec,
                animation: () => toastWindow.Alpha = 0.0f,
                completion: () => toastWindow.Hidden = true);
        }

        private void InitiateTimer(double durationInSec)
        {
            NSTimer.CreateScheduledTimer(durationInSec, (obj) =>
            {
                FadeOutAndHide();
            });
        }

        private void PrepareUIElements()
        {
            InitializeMessageLabel();
            InitializeWindowStyle();

            SetupLayoutConstraints();
        }

        private void InitializeMessageLabel()
        {
            messageLabel = new UILabel
            {
                TextAlignment = UITextAlignment.Center,
                Lines = 2,
            };

            messageLabel.Font = messageLabel.Font.WithSize(13);

            toastViewController.View.Add(messageLabel);
        }

        private void InitializeWindowStyle()
        {
            toastWindow.BackgroundColor = UIColor.White;
            toastWindow.Layer.CornerRadius = ToastCornerRadius;
            toastWindow.Layer.BorderColor = UIColor.White.CGColor;

            // Colorado color
            ////toastWindow.Layer.BorderColor = new UIColor(
            ////ConvertByteColorToFloatColor(135),
            ////ConvertByteColorToFloatColor(28),
            ////ConvertByteColorToFloatColor(30),
            ////1.0f).CGColor;

            toastWindow.Layer.BorderWidth = ToastBorderWidth;

            toastWindow.Layer.ShadowColor = UIColor.Black.CGColor;
            toastWindow.Layer.ShadowOpacity = ShadowOpacity;
            toastWindow.Layer.ShadowRadius = ShadowRadius;
            toastWindow.Layer.ShadowOffset = new CGSize(ShadowOffset, ShadowOffset);
        }

        private void SetupLayoutConstraints()
        {
            AutoLayoutToolBox.AlignLeftAnchorToLeftOf(messageLabel, toastViewController.View, ToastPaddingSize);
            AutoLayoutToolBox.AlignRightAnchorToRightOf(messageLabel, toastViewController.View, -ToastPaddingSize);
            AutoLayoutToolBox.AlignCenterYAnchorToCenterYOf(messageLabel, toastViewController.View);
        }

        private float ConvertByteColorToFloatColor(byte colorInByte)
        {
            return (float)colorInByte / 255.0f;
        }
    }
}
