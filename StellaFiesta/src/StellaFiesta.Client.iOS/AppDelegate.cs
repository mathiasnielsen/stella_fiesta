using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SVG.Forms.Plugin.iOS;
using UIKit;

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

            Facebook.CoreKit.ApplicationDelegate.SharedInstance.FinishedLaunching(uiApplication, launchOptions);
            SvgImageRenderer.Init();

            var setup = new Setup();
            setup.Bootstrap();

            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            var openUrlOptions = new UIApplicationOpenUrlOptions(options);
            Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(app, url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);

            return base.OpenUrl(app, url, options);
        }
    }
}
