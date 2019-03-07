using System;
using StellaFiesta.Client.CoreStandard.Utilities.Logging;
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
        private readonly Logger logger = new Logger(nameof(SignInPageRenderer));

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ////UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            ////UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, true);
        }

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

        private async void OnFacebookClicked(object sender, EventArgs e)
        {
            var facebookService = new FacebookService(this);
            var loginResult = await facebookService.LogInAsync();
            if (loginResult?.Token != null)
            {
                logger.Info("Did not log in");
            }
        }
    }
}
