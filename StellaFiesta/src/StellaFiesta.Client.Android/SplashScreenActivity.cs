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
        Theme = "@style/MainTheme",
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

            FacebookSdk.ApplicationId = "534663733642417";
            CallbackManager = CallbackManagerFactory.Create();
            ////FacebookSdk.SdkInitialize(ApplicationContext);
            ////AppEventsLogger.ActivateApp(this);

            var setup = new Setup();
            setup.Bootstrap(this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            CallbackManager.OnActivityResult(requestCode, resultCode, data);
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}

