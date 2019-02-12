using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class EnterPasswordViewModel : BindableViewModelBase
    {
        private IStorageService _storageService;

        public EnterPasswordViewModel(IConnectivityService connectivityService)
            : base(connectivityService)
        {
        }
    }
}
