using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public abstract class AuthenticationServiceBase
    {
        private const int ImageSize = 100;

        private readonly IMessagingCenterForwarder _messagingCenterForwarder;

        public AuthenticationServiceBase(IMessagingCenterForwarder messagingCenterForwarder)
        {
            _messagingCenterForwarder = messagingCenterForwarder;
        }

        public void SignOut()
        {
            OnSignOut();
            _messagingCenterForwarder.Publish(this, new LogOutMessage());
        }

        public async Task<UserProfile> GetProfileAsync(int imageSize = ImageSize)
        {
            var userProfile = await GetNativeProfileAsync(imageSize);
            return userProfile;
        }

        protected virtual void OnSignOut()
        {
        }

        protected abstract Task<UserProfile> GetNativeProfileAsync(int imageSize);
    }
}
