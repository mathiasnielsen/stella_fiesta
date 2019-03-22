using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Facebook.AppEvents;

namespace StellaFiesta.Client.Droid
{
    [Activity(
        Label = "StellaFiesta.Client",
        Icon = "@mipmap/icon",
        Theme = "@style/LauncherTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Name = "com.kirkegaardbusiness.Stella_Fiesta.SplashScreenActivity")]
    public class SplashScreenActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static ICallbackManager CallbackManager { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // NOPE! But make put all this into activity
            // https://xamarinhelp.com/creating-splash-screen-xamarin-forms/
            SetTheme(Resource.Style.MainTheme);

            InitializeFacebook();

            var setup = new Setup();
            setup.Bootstrap(this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
            base.OnActivityResult(requestCode, resultCode, data);
        }

        private void InitializeFacebook()
        {
            FacebookSdk.ApplicationId = "534663733642417";
            CallbackManager = CallbackManagerFactory.Create();
        }
    }
}