using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class ViewBase : ContentPage
    {
        private View loadingView;

        public ViewBase()
        {
            LoadingManager = CreateLoadingManager();
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
                loadingView = new Grid()
                {
                    BackgroundColor = Color.Black.MultiplyAlpha(0.2),
                    IsVisible = false,
                };

                ////var centerX = Constraint.RelativeToParent(parent => 0);
                ////var centerY = Constraint.RelativeToParent(parent => 0);
                ////var width = Constraint.RelativeToParent(parent => parent.Width);
                ////var height = Constraint.RelativeToParent(parent => parent.Height);

                ////relativeLayoutContent.Children.Add(loadingView, centerX, centerY, width, height);

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
