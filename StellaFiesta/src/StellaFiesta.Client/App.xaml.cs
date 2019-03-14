using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard;
using StellaFiesta.Client.CoreStandard.Managers;
using StellaFiesta.Client.CoreStandard.Services;
using StellaFiesta.Client.Features.Account;
using StellaFiesta.Client.Features.Common;
using StellaFiesta.Client.Services;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StellaFiesta.Client
{
    public partial class App : Application
    {
        private static IUnityContainer _container;

        public App()
        {
            InitializeComponent();

            Resources = StylesFactory.GenerateStyles(Resources);

            ContentPage startPage = null;
            var authenticationService = _container.Resolve<IAuthenticationService>();
            if (authenticationService.IsLoggedIn)
            {
                startPage = new HomeView();
            }
            else
            {
                startPage = new SignInView();
            }

            var navigationPage = new NavigationPage(startPage)
            {
                BarTextColor = Color.White,
            };

            MainPage = navigationPage;
        }

        public static IUnityContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }

                _container = new UnityContainer();
                ////_container.AddExtension(new InitializationExtension());
                RegisterCoreTypes();

                return _container;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            PrepareAppCenter();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static void RegisterCoreTypes()
        {
            // Services
            _container.RegisterSingleton<INavigationService, NavigationService>();
            _container.RegisterSingleton<IBookingApi, BookingApi>();
            _container.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();
            _container.RegisterSingleton<IDialogService, DialogService>();
            _container.RegisterSingleton<IConnectivityService, ConnectivityService>();
            _container.RegisterSingleton<ILocalNotificationService, LocalNotificationService>();

            // Managers
            _container.RegisterSingleton<ISecurityManager, SecurityManager>();

            // Others
            _container.RegisterSingleton<IMessagingCenterForwarder, MessagingCenterForwarder>();
        }

        private void PrepareAppCenter()
        {
            var iOSAppCenterKey = "ios=3bd9daf5-3a98-4446-9132-eac22f377a91;";
            var androidCenterKey = "android=83cb784c-355d-47f0-b4a2-fba7ccccae2a";
            AppCenter.Start($"{iOSAppCenterKey}{androidCenterKey}", typeof(Analytics), typeof(Crashes));
        }
    }
}
