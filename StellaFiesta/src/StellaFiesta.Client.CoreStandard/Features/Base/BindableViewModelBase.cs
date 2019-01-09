using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class BindableViewModelBase : ViewModelBase
    {
        public BindableViewModelBase()
        {
            LoadingManager = new LoadingManager();
        }

        protected ILoadingManager LoadingManager { get; set; }

        protected Dictionary<string, string> NavigationParameters { get; set; }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            private set { Set(ref isLoading, value); }
        }

        public async void ViewInitialized(Dictionary<string, string> navigationParameters)
        {
            NavigationParameters = navigationParameters ?? new Dictionary<string, string>();
            await OnViewInitialized(NavigationParameters);
        }

        public async void ViewLoading()
        {
            LoadingManager.Loading += OnLoading;
            LoadingManager.Completed += OnCompleted;
            await OnLoadAsync();
        }

        public async void ViewUnloading()
        {
            LoadingManager.Loading -= OnLoading;
            LoadingManager.Completed -= OnCompleted;
            await OnUnloadAsync();
        }

        public virtual async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            await Task.FromResult(true);
        }

        public virtual async Task OnLoadAsync()
        {
            await Task.FromResult(true);
        }

        public virtual async Task OnUnloadAsync()
        {
            await Task.FromResult(true);
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            IsLoading = false;
        }

        private void OnLoading(object sender, EventArgs e)
        {
            IsLoading = true;
        }
    }
}
