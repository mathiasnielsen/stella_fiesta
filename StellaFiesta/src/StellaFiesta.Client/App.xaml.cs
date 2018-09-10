using System;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StellaFiesta.Client;
using StellaFiesta.Client.Core;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StellaFiesta.Client
{
    public partial class App : Application
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container != null) return _container;

                _container = new UnityContainer();
                ////_container.AddExtension(new InitializationExtension());
                RegisterCoreTypes();

                return _container;
            }
        }

        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage();
            var navigationPage = new NavigationPage(mainPage);
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
            _container.RegisterSingleton<INavigationService, NavigationService>();
        }
    }
}
