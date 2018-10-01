using System;
using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Facebook;

namespace StellaFiesta.Client.Droid
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsLoggedIn => AccessToken.CurrentAccessToken != null && AccessToken.CurrentAccessToken.IsExpired == false;

        public Task<UserProfile> GetProfileAsync()
        {
            var accessToken = AccessToken.CurrentAccessToken;
            if (accessToken.IsExpired == false)
            {
                var userProfile = new UserProfile();
                userProfile.Name = Profile.CurrentProfile.Name;
                var imageUri = Profile.CurrentProfile.GetProfilePictureUri(100, 100);
            }

            return null;
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
