using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SVG.Forms.Plugin.iOS;
using UIKit;
using UserNotifications;

namespace StellaFiesta.Client.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            PrepareFacebookLogin(uiApplication, launchOptions);
            PrepareSVGImageRenderer();
            AskForLocalNotificationPermissions();

            var setup = new Setup();
            setup.Bootstrap();

            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            HandleReturnFromFacebook(app, url, options);
            return base.OpenUrl(app, url, options);
        }

        private void PrepareFacebookLogin(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Facebook.CoreKit.ApplicationDelegate.SharedInstance.FinishedLaunching(uiApplication, launchOptions);
        }

        private void AskForLocalNotificationPermissions()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Ask the user for permission to get notifications on iOS 10.0+
                UNUserNotificationCenter.Current.RequestAuthorization(
                        UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                        (approved, error) => { });
            }
        }

        private void PrepareSVGImageRenderer()
        {
            SvgImageRenderer.Init();
        }

        private void HandleReturnFromFacebook(UIApplication app, NSUrl url, NSDictionary options)
        {
            var openUrlOptions = new UIApplicationOpenUrlOptions(options);
            Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(
                app,
                url,
                openUrlOptions.SourceApplication,
                openUrlOptions.Annotation);
        }
    }
}
