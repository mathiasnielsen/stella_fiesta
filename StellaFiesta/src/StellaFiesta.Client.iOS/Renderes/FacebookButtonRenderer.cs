using System;
using Facebook.LoginKit;
using StellaFiesta.Client.Controls;
using StellaFiesta.Client.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookButtonRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class FacebookButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
                var loginButton = new LoginButton();
                SetNativeControl(loginButton);   
            }
        }
    }
}
