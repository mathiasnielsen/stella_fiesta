using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class BindableViewModelBase : ViewModelBase
    {
        private readonly IConnectivityService _connectivityService;

        private bool _isLoading;
        private bool _isConnected;
        private bool _isShowingOfflineState;
        private string _loadingText;

        public BindableViewModelBase(
            IConnectivityService connectivityService)
        {
            _connectivityService = connectivityService;
            LoadingManager = new LoadingManager();
        }

        protected ILoadingManager LoadingManager { get; set; }

        protected Dictionary<string, string> NavigationParameters { get; set; }

        public bool IsLoading
        {
            get { return _isLoading; }
            private set { Set(ref _isLoading, value); }
        }

        public bool IsConnected
        {
            get { return IsConnected; }
            private set { Set(ref _isConnected, value); }
        }

        public bool IsShowingOfflineState
        {
            get { return _isShowingOfflineState; }
            set { Set(ref _isShowingOfflineState, value); }
        }

        public string LoadingText
        {
            get { return _loadingText; }
            set { Set(ref _loadingText, value); }
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
            _connectivityService.IsConnectedChanged += IsConnectedChanged;

            await OnLoadAsync();
        }

        public async void ViewUnloading()
        {
            LoadingManager.Loading -= OnLoading;
            LoadingManager.Completed -= OnCompleted;
            _connectivityService.IsConnectedChanged -= IsConnectedChanged;
            await OnUnloadAsync();
        }

        public async void ViewFinalized()
        {

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
            LoadingText = string.Empty;
        }

        private void OnLoading(object sender, EventArgs e)
        {
            IsLoading = true;
        }

        private void IsConnectedChanged(object sender, bool isConnected)
        {
            OnIsConnectedChanged(isConnected);
        }

        protected virtual void OnIsConnectedChanged(bool isConnected)
        {
        }
    }
}
