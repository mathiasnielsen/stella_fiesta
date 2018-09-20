using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class ViewBase : MasterView
    {
        private ContentOverlay loadingView;

        public ViewBase()
        {
            LoadingManager = CreateLoadingManager();
            ControlTemplate = (ControlTemplate)Application.Current.Resources["MainPageTemplate"];
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetOverlay();
        }

        private void SetOverlay()
        {
            if (Content is Grid relativeLayoutContent)
            {
                loadingView = new ContentOverlay()
                {
                    BackgroundColor = Color.Black.MultiplyAlpha(0.1),
                    IsVisible = false,
                };

                relativeLayoutContent.Children.Add(loadingView);
            }
            else
            {
                throw new Exception("Page needs to have relative layout as root view");
            }
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
            loadingView.IsVisible = true;
        }

        private void LoadingManager_Completed(object sender, EventArgs e)
        {
            loadingView.IsVisible = false;
        }
    }
}
