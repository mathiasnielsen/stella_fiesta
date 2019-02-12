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

        protected virtual void OnSignOut()
        {
        }
    }
}
