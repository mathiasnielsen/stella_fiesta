using System;
using System.Threading.Tasks;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class DialogService : IDialogService
    {
        public async Task<bool> ShowMessageAsync(string title, string message, string cancelText, string acceptText)
        {
            var didAccept = await Application.Current.MainPage.DisplayAlert(title, message, acceptText, cancelText);
            return didAccept;
        }

        public async Task<string> ShowActionSheetAsync(string title, string cancelText, string destructionText, string[] buttons)
        {
            var selection = await Application.Current.MainPage.DisplayActionSheet(title, cancelText, destructionText, buttons);
            return selection;
        }
    }
}
