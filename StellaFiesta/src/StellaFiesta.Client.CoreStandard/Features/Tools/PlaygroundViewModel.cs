using System;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class PlaygroundViewModel : BindableViewModelBase
    {
        private readonly IToastService toastService;

        public PlaygroundViewModel(IToastService toastService)
        {
            this.toastService = toastService;

            ShowToastCommand = new RelayCommand(ShowToast);
        }

        public RelayCommand ShowToastCommand { get; }

        private void ShowToast()
        {
            toastService.LongAlert("This is a toast. this is a toast. this is a toast. htis is asdalksvnfklsklf jalkj ka akljklaj kald lkad lkad");
        }
    }
}
