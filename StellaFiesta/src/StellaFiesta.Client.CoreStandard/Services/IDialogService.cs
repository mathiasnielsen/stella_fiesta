using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IDialogService
    {
        Task ShowMessageAsync(string title, string message, string cancelText);

        Task<bool> ShowMessageAsync(string title, string message, string cancelText, string acceptText);

        Task<string> ShowActionSheetAsync(string title, string cancelText, string destructionText, string[] buttons);
    }
}
