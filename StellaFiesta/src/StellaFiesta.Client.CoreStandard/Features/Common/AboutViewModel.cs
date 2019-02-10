using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class AboutViewModel : BindableViewModelBase
    {
        public AboutViewModel(IConnectivityService connectivityService)
            : base(connectivityService)
        {
        }

        public async override Task OnLoadAsync()
        {
            await Task.Delay(2000);
            using (LoadingManager.CreateLoadingScope())
            {
                LoadingText = "Loading...";
                await Task.Delay(5000);
            }
        }
    }
}
