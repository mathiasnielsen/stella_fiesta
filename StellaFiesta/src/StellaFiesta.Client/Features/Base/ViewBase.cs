using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class ViewBase : ContentPage
    {
        public ViewBase()
        {
            LoadingManager = CreateLoadingManager();
            ControlTemplate = (ControlTemplate)Application.Current.Resources["MainPageTemplate"];
        }

        protected ILoadingManager LoadingManager { get; }

        private ILoadingManager CreateLoadingManager()
        {
            var loadingManager = new LoadingManager();

            loadingManager.Loading += LoadingManager_Loading;
            loadingManager.Completed += LoadingManager_Completed;

            return loadingManager;
        }

        private void LoadingManager_Loading(object sender, EventArgs e)
        {
            ////LoadingView.ProgressLabel.IsVisible = LoadingManager.UseProgress;
            ////loadingView.IsVisible = true;
        }

        private void LoadingManager_Completed(object sender, EventArgs e)
        {
            ////loadingView.IsVisible = false;
        }
    }
}
