using System;
using System.Linq;
using StellaFiesta.Client.CoreStandard;
using StellaFiesta.Models;
using Xamarin.Forms;
using ActualDevice = Xamarin.Forms.Device;

namespace StellaFiesta.Client.Features.Account
{
    public abstract class SignInViewBase : BindableViewBase<SignInViewModel>
    {
    }

    public partial class SignInView : SignInViewBase
    {
        public SignInView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            login_facebook_btn.Clicked += OnFacebookLoginClicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            login_facebook_btn.Clicked -= OnFacebookLoginClicked;
        }

        private void OnFacebookLoginClicked(object sender, EventArgs e)
        {
            var clientId = "534663733642417";
            var apiRequest =
                "https://www.facebook.com/dialog/oauth?client_id="
                + clientId
                + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                await ViewModel.SetFacebookUserProfileAsync(accessToken);

                SetPageContent(ViewModel.FacebookProfile);
            }
        }

        private void SetPageContent(FacebookProfile facebookProfile)
        {
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(8, 30),
                Children =
                {
                    new Label
                    {
                        Text = facebookProfile.Name,
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.Id,
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.IsVerified.ToString(),
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.Devices.FirstOrDefault().Os,
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.Gender,
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.AgeRange.Min.ToString(),
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.Picture.Data.Url,
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                    new Label
                    {
                        Text = facebookProfile.Cover.Source,
                        TextColor = Color.Black,
                        FontSize = 22,
                    },
                }
            };
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (ActualDevice.RuntimePlatform == ActualDevice.UWP)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in=", StringComparison.Ordinal));

                return accessToken;
            }

            return string.Empty;
        }
    }
}