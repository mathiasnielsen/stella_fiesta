using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using StellaFiesta.Client.Droid;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

// GOOD GIT https://gist.github.com/jaganjan/ecd8b6523ddebbaf43e7
[assembly: Xamarin.Forms.Dependency(typeof(FacebookService))]
[assembly: Permission(Name = Android.Manifest.Permission.Internet)]
[assembly: Permission(Name = Android.Manifest.Permission.WriteExternalStorage)]
[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/facebook_app_id")]
[assembly: MetaData("com.facebook.sdk.ApplicationName", Value = "@string/facebook_app_name")]

namespace StellaFiesta.Client.Droid
{
    public class FacebookService : Java.Lang.Object, IFacebookCallback
    {
        private readonly List<string> readPermissions = new List<string> { "public_profile", "email" };
        private readonly Activity currentActivity;

        private TaskCompletionSource<bool> _loginTaskCompletionSource;

        public FacebookService(Activity currentActivity, ICallbackManager callbackManager)
        {
            this.currentActivity = currentActivity;
            LoginManager.Instance.RegisterCallback(callbackManager, this);
        }

        public Task<bool> LoginAsync()
        {
            _loginTaskCompletionSource = new TaskCompletionSource<bool>();
            LoginManager.Instance.LogInWithReadPermissions(currentActivity, readPermissions);
            return _loginTaskCompletionSource.Task;
        }

        public void OnCancel()
        {
            _loginTaskCompletionSource.SetResult(false);
        }

        public void OnError(FacebookException error)
        {
            _loginTaskCompletionSource.SetResult(false);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            _loginTaskCompletionSource.SetResult(true);
        }
    }
}