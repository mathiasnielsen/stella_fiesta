using System;
using Android.App;
using Android.Content;
using StellaFiesta.Client.Droid;
using StellaFiesta.Client.Features.Account;
using Xamarin.Facebook;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SignInView), typeof(SignInPageRenderer))]
namespace StellaFiesta.Client.Droid
{
    public class SignInPageRenderer : PageRenderer
    {
        private readonly FacebookService _facebookService;

        public SignInPageRenderer(Context context)
            : base(context)
        {
            var activity = this.Context as Activity;
            _facebookService = new FacebookService(activity, SplashScreenActivity.CallbackManager);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;
            var page = (SignInView)Element;

            if (e.OldElement != null)
            {
                page.FacebookSignInClicked -= OnFacebookButtonClicked;
            }

            if (e.NewElement != null)
            {
                page.FacebookSignInClicked += OnFacebookButtonClicked;
            }
        }

        private async void OnFacebookButtonClicked(object sender, EventArgs e)
        {
            var didLogin = await _facebookService.LoginAsync();
        }
    }
}
