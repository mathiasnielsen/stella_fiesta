using System.Threading.Tasks;
using Facebook.LoginKit;
using Foundation;
using UIKit;

namespace StellaFiesta.Client.iOS
{
    public class FacebookService
    {
        private readonly string[] _readPermissions = { "public_profile", "email" };

        private LoginManager loginManager;
        private UIViewController currentViewController;

        public FacebookService(UIViewController currentViewController)
        {
            this.currentViewController = currentViewController;

            loginManager = new LoginManager();

            // Using the web version, acutally lets you log out of the app.
            ////loginManager.LoginBehavior = LoginBehavior.Web;
        }

        public async Task<LoginManagerLoginResult> LogInAsync()
        {
            try
            {
                var result = await loginManager.LogInWithReadPermissionsAsync(_readPermissions, currentViewController);
                if (result.IsCancelled == false)
                {
                    // Canncelled
                }
                else
                {
                    return result;
                }
            }
            catch (NSErrorException errorException)
            {
                // Failed
                System.Diagnostics.Debug.WriteLine("Failed to login: " + errorException.Message);
            }

            return null;
        }
    }
}
