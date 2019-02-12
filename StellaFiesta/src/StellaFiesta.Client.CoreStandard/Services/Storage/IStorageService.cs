using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IStorageService
    {
        void SavePreference<TData>(string key, TData data);

        TData LoadPreference<TData>(string key);

        void ClearPreferences();

        // TODO:
        ////Task SaveDataAsync<TData>(string key, TData data);

        // TODO:
        ////Task LoadDataAsync<TData>(string key);
    }
}
