using System;
using StellaFiesta.Client.Features.Account;
using StellaFiesta.Client.iOS;
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

        private async void OnFacebookClicked(object sender, EventArgs e)
        {
            var facebookService = new FacebookService(this);
            var loginResult = await facebookService.LogInAsync();
        }
    }
}
