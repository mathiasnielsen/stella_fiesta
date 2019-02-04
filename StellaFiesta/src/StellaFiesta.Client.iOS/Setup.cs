using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.iOS
{
    public class Setup
    {
        public void Bootstrap()
        {
            Register();
        }

        private void Register()
        {
            App.Container.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            App.Container.RegisterSingleton<IToastService, ToastService>();
        }
    }
}
