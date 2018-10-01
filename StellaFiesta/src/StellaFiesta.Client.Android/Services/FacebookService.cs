using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

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
