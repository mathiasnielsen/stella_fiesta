using System;

namespace StellaFiesta.Client.CoreStandard.Managers
{
    public class SecurityManager : ISecurityManager
    {
        private const string VerySecretPassword = "2609";
        private const string HasBookingPermissionKey = nameof(HasBookingPermissionKey);

        private readonly IStorageService _storageService;
        private readonly IMessagingCenterForwarder _messagingCenterForwarder;

        public SecurityManager(
            IStorageService storageService,
            IMessagingCenterForwarder messagingCenterForwarder)
        {
            _storageService = storageService;
            _messagingCenterForwarder = messagingCenterForwarder;

            _messagingCenterForwarder.Subscribe(this, LoggedOut);
        }

        public bool HasBookingAccess => _storageService.LoadPreference<bool>(HasBookingPermissionKey);

        public bool GiveBookingPermissionIfPasswordIsCorrect(string userInput)
        {
            var isPermissiongranted = userInput == VerySecretPassword;
            if (isPermissiongranted)
            {
                _storageService.SavePreference<bool>(HasBookingPermissionKey, true);
            }

            return isPermissiongranted;
        }

        private void LoggedOut(Message logOutMessage)
        {
            _storageService.ClearPreferences();
        }
    }
}
