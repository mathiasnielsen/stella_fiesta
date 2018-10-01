using System;
using StellaFiesta.Client.Features.Account;
using StellaFiesta.Client.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SignInView), typeof(SignInPageRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class SignInPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var page = (SignInView)Element;

            if (e.OldElement != null)
            {
                page.FacebookSignInClicked -= OnFacebookClicked;
            }

            if (e.NewElement != null)
            {
                page.FacebookSignInClicked += OnFacebookClicked;
            }
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.Default;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, true);
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

            SetNeedsStatusBarAppearanceUpdate();
            ParentViewController.ParentViewController.ParentViewController.SetNeedsStatusBarAppearanceUpdate();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, true);
            SetNeedsStatusBarAppearanceUpdate();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
        }

        private async void OnFacebookClicked(object sender, EventArgs e)
        {
            var facebookService = new FacebookService(this);
            var loginResult = await facebookService.LogInAsync();
        }
    }
}
