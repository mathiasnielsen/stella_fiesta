using System;
using StellaFiesta.Client;
using StellaFiesta.Client.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FacebookLoginPage), typeof(FacebookLoginPageRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class FacebookLoginPageRenderer : PageRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var facebookService = new FacebookService(this);
            var test = await facebookService.LogInAsync();
        }
    }
}
