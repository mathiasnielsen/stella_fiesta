using System.Threading.Tasks;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.iOS
{
    public class AuthenticationService : AuthenticationServiceBase, IAuthenticationService
    {
        private const int ImageSize = 100;
        private LoginManager loginManager;

        public AuthenticationService(IMessagingCenterForwarder messagingCenterForwarder)
            : base(messagingCenterForwarder)
        {
            loginManager = new LoginManager();
        }

        public bool IsLoggedIn => AccessToken.CurrentAccessTokenIsActive;

        public Task<UserProfile> GetProfileAsync()
        {
            var completionTask = new TaskCompletionSource<UserProfile>();
            var accessToken = AccessToken.CurrentAccessToken;
            if (accessToken.IsExpired == false)
            {
                Profile.LoadCurrentProfile((Profile profile, NSError error) =>
                {
                    var userProfile = new UserProfile
                    {
                        UserId = profile.UserId,
                        Name = profile.Name,
                    };

                    userProfile.ImageUrl = profile.ImageUrl(
                        ProfilePictureMode.Square,
                        new CoreGraphics.CGSize(ImageSize, ImageSize)).AbsoluteString;

                    completionTask.TrySetResult(userProfile);
                });
            }

            return completionTask.Task;
        }

        protected override void OnSignOut()
        {
            loginManager.LogOut();
        }
    }
}
