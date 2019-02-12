using System;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class EnterPasswordViewModel : BindableViewModelBase
    {
        private readonly ISecurityManager _securityManager;
        private readonly IToastService _toastService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        private string _password;

        public EnterPasswordViewModel(
            IConnectivityService connectivityService,
            ISecurityManager securityManager,
            IToastService toastService,
            IDialogService dialogService,
            INavigationService navigationService)
            : base(connectivityService)
        {
            _securityManager = securityManager;
            _toastService = toastService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            TryOutPasswordCommand = new RelayCommand(TryOutPassword);
            DismissCommand = new RelayCommand(Dismiss);
        }

        public RelayCommand TryOutPasswordCommand { get; }

        public RelayCommand DismissCommand { get; }

        public string TitleText => "Missing the secret password";

        public string ContentText => "In order to make bookings/remove bookings, you need to enter the very secret code below";

        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }

        private async void TryOutPassword()
        {
            var isPermissionGranted = _securityManager.GiveBookingPermissionIfPasswordIsCorrect(Password);
            if (isPermissionGranted)
            {
                await _dialogService.ShowMessageAsync("Permission granted", "You can now use the app for booking stella", "continue");
                Dismiss();
            }
            else
            {
                var errorText = GetWrongPasswordText();
                _toastService.LongAlert(errorText);
            }
        }

        private void Dismiss()
        {
            _navigationService.DismissModal();
        }

        private string GetWrongPasswordText()
        {
            var wrongPasswordTexts = new string[]
            {
                "Pfff... that is wrong.",
                "That wasn't right...",
                "Wrong... wrong wrong wrong...",
                "This is not the password",
            };

            var random = new Random();
            var textIndex = random.Next(wrongPasswordTexts.Length);
            var errorText = wrongPasswordTexts[textIndex];
            return errorText;
        }
    }
}
