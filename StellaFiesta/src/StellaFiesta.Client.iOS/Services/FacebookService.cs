using System;
using System.Threading.Tasks;
using Facebook.LoginKit;
using Foundation;
using UIKit;

namespace StellaFiesta.Client.iOS
{
    public class FacebookService //: IFacebookAuthenticationManager
    {
        private readonly string[] _readPermissions = { "public_profile", "email" };

        private LoginManager loginManager;
        private UIViewController currentViewController;

        public FacebookService(UIViewController currentViewController)
        {
            this.currentViewController = currentViewController;

            loginManager = new LoginManager();
        }

        public async Task<bool> LogInAsync()
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
                    return true;
                }
            }
            catch (NSErrorException errorException)
            {
                // Failed
                System.Diagnostics.Debug.WriteLine("Failed to login: " + errorException.Message);
            }

            return false;
        }

        public void SignOut()
        {
            loginManager.LogOut();
        }
    }
}
