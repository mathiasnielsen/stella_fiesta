using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

namespace StellaFiesta.Client.Droid
{
    public class AuthenticationService : AuthenticationServiceBase, IAuthenticationService
    {
        public AuthenticationService(IMessagingCenterForwarder messagingCenterForwarder)
            : base(messagingCenterForwarder)
        {
        }

        public bool IsLoggedIn =>
            AccessToken.CurrentAccessToken != null && AccessToken.CurrentAccessToken.IsExpired == false;

        protected override Task<UserProfile> GetNativeProfileAsync(int imageSize)
        {
            var accessToken = AccessToken.CurrentAccessToken;
            if (accessToken.IsExpired == false)
            {
                var userProfile = new UserProfile
                {
                    Name = Profile.CurrentProfile.Name,
                };

                var imageUri = Profile.CurrentProfile.GetProfilePictureUri(imageSize, imageSize);
                userProfile.ImageUrl = imageUri.ToString();
            }

            return null;
        }

        protected override void OnSignOut()
        {
            LoginManager.Instance.LogOut();
        }
    }
}
