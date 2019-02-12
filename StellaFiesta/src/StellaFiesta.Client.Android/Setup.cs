using Android.Content;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Droid
{
    public class Setup
    {
        public void Bootstrap(Context context)
        {
            Register(context);
        }

        private void Register(Context context)
        {
            App.Container.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            App.Container.RegisterSingleton<IToastService, ToastService>();
            App.Container.RegisterSingleton<IStorageService, StorageService>();
        }
    }
}
