using System;
using Android.App;
using Android.Content;
using Newtonsoft.Json;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Droid
{
    public class StorageService : IStorageService
    {
        private const string PreferenceDictionaryKey = nameof(PreferenceDictionaryKey);

        private readonly ISharedPreferences _sharedPreferences;

        public StorageService()
        {
            _sharedPreferences = CreateSharedPreferencesFile(Application.Context);
        }

        public TData LoadPreference<TData>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key is invalid");
            }

            var keyExists = DoesPreferenceKeyExist(key);
            if (keyExists)
            {
                var dataAsJsonFormatted = _sharedPreferences.GetString(key, null);
                var data = JsonConvert.DeserializeObject<TData>(dataAsJsonFormatted);
                return data;
            }

            return default(TData);
        }

        public void SavePreference<TData>(string key, TData data)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key is invalid");
            }

            var dataAsJsonFormatted = JsonConvert.SerializeObject(data);
            _sharedPreferences
                .Edit()
                .PutString(key, dataAsJsonFormatted)
                .Commit();
        }

        private bool DoesPreferenceKeyExist(string key)
        {
            return _sharedPreferences.Contains(key);
        }

        private static ISharedPreferences CreateSharedPreferencesFile(Context context)
        {
            return context.GetSharedPreferences(PreferenceDictionaryKey, FileCreationMode.Private);
        }
    }
}
