using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public abstract class AuthenticationServiceBase
    {
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

        public async Task<UserProfile> GetProfileAsync()
        {
            var userProfile = await GetNativeProfileAsync();
            return userProfile;
        }

        protected virtual void OnSignOut()
        {
        }

        protected abstract Task<UserProfile> GetNativeProfileAsync();
    }
}
