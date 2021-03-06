using System;
using System.Threading.Tasks;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.iOS
{
    public class AuthenticationService : AuthenticationServiceBase, IAuthenticationService
    {
        private readonly LoginManager _loginManager;

        public AuthenticationService(IMessagingCenterForwarder messagingCenterForwarder)
            : base(messagingCenterForwarder)
        {
            _loginManager = new LoginManager();
        }

        public bool IsLoggedIn => AccessToken.CurrentAccessTokenIsActive;

        protected override Task<UserProfile> GetNativeProfileAsync(int imageSize)
        {
            var completionTask = new TaskCompletionSource<UserProfile>();
            var accessToken = AccessToken.CurrentAccessToken;
            if (accessToken.IsExpired == false)
            {
                Profile.LoadCurrentProfile((Profile profile, NSError error) =>
                {
                    if (error != null)
                    {
                        completionTask.TrySetException(new Exception($"An exception has been registered, ex: {error.LocalizedDescription}"));
                        return;
                    }

                    if (profile == null)
                    {
                        completionTask.TrySetException(new Exception("Profile is null"));
                        return;
                    }

                    var userProfile = new UserProfile
                    {
                        UserId = profile.UserId,
                        Name = profile.Name,
                    };

                    userProfile.ImageUrl = profile.ImageUrl(
                        ProfilePictureMode.Square,
                        new CoreGraphics.CGSize(imageSize, imageSize)).AbsoluteString;

                    completionTask.TrySetResult(userProfile);
                });
            }

            return completionTask.Task;
        }

        protected override void OnSignOut()
        {
            _loginManager.LogOut();
        }
    }
}
