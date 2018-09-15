using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using StellaFiesta.Client.Core;
using Xamarin.Auth;

namespace StellaFiesta.Client.Features.Common
{
    public abstract class HomeViewBase : BindableViewBase<HomeViewModel>
    {
    }

    public partial class HomeView : HomeViewBase
    {
        // New and better tutorial? NO!
        // https://www.joesauve.com/using-xamarin-auth-with-xamarin-forms/

        // Maybe use this?
        //https://manage.auth0.com/#/tenant/billing/subscription

        private const string AppName = "StellaFiesta";

        private const string FacebookClientId = "534663733642417";
        private const string FacebookClientSecrect = "17357e48347723a3824c3358bc88fef3";
        private const string FacebookAuthorizeUrl = "https://m.facebook.com/dialog/oauth/";
        private const string FacebookRedirectUrl = "http://www.facebook.com/connect/login_success.html";

        private const string GoogleProjectNumber = "81929190353";
        private const string GoogleClientId = "81929190353-e4bl452s15les5othlqo8fgu30qo88bq.apps.googleusercontent.com";

        // https://github.com/xamarin/xamarin-forms-samples/blob/master/WebServices/OAuthNativeFlow/OAuthNativeFlow/Constants.cs
        private const string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        private const string GoogleRedirectUrl = "https://www.google.dk";
        private const string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";

        private Xamarin.Auth.Account account;
        private AccountStore store;

        public HomeView()
        {
            InitializeComponent();

            // DAMN IT! It has to NOT be in a webview.

            // Here is android version.
            // https://github.com/xamarin/monodroid-samples/blob/master/google-services/SigninQuickstart/SigninQuickstart/MainActivity.cs

            store = AccountStore.Create();
            var accounts = store.FindAccountsForService(AppName);
            account = accounts.FirstOrDefault();
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            // Inspiration
            // https://github.com/xamarin/xamarin-forms-samples/blob/master/WebServices/OAuthNativeFlow/OAuthNativeFlow/OAuthNativeFlowPage.xaml.cs

            var authorizeUri = new Uri(GoogleAuthorizeUrl);
            var redirectUri = new Uri(GoogleRedirectUrl);
            var accessTokenUri = new Uri(GoogleAccessTokenUrl);

            var authenticator = new OAuth2Authenticator(
                clientId: GoogleClientId,
                clientSecret: string.Empty,
                scope: null,
                authorizeUrl: authorizeUri,
                redirectUrl: redirectUri,
                accessTokenUrl: accessTokenUri);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            // Remember info in link in app delegate and mainactivity droid
            // https://github.com/xamarin/Xamarin.Auth/issues/225
            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                var userInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
                var request = new OAuth2Request("GET", new Uri(userInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, AppName);
                }

                await store.SaveAsync(account = e.Account, AppName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }
    }
}
