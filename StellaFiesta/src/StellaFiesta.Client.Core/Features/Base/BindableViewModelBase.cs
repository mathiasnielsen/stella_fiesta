using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellaFiesta.Client.Core
{
    public class BindableViewModelBase : ViewModelBase
    {
        protected Dictionary<string, string> NavigationParameters { get; set; }

        public async void ViewInitialized(Dictionary<string, string> navigationParameters)
        {
            NavigationParameters = navigationParameters ?? new Dictionary<string, string>();
            await OnViewInitialized(NavigationParameters);
        }

        public async void ViewReloading()
        {
            await OnViewReloaded();
        }

        public virtual async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            await Task.FromResult(true);
        }

        public virtual async Task OnViewReloaded()
        {
            await Task.FromResult(true);
        }
    }
}
