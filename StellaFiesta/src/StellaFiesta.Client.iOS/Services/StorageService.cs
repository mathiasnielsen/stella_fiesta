using System;
using Foundation;
using Newtonsoft.Json;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.iOS
{
    public class StorageService : IStorageService
    {
        private const string PreferenceDictionaryKey = nameof(PreferenceDictionaryKey);

        private readonly NSMutableDictionary _preferenceDictionary;

        public StorageService()
        {
            _preferenceDictionary = GetOrCreatePreferenceDictionary();
        }

        public void SavePreference<TData>(string key, TData data)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key is invalid");
            }

            var dataAsJsonFormatted = JsonConvert.SerializeObject(data);
            _preferenceDictionary[key] = new NSString(dataAsJsonFormatted);

            NSUserDefaults.StandardUserDefaults[PreferenceDictionaryKey] = _preferenceDictionary;
            NSUserDefaults.StandardUserDefaults.Synchronize();
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
                var dataAsJsonFormatted = (NSString)_preferenceDictionary[key];
                var data = JsonConvert.DeserializeObject<TData>(dataAsJsonFormatted);
                return data;
            }

            return default(TData);
        }

        private bool DoesPreferenceKeyExist(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key is invalid");
            }

            return _preferenceDictionary.ContainsKey(key);
        }

        private NSMutableDictionary GetOrCreatePreferenceDictionary()
        {
            var dictionary = new NSMutableDictionary();

            var existingDictionary = NSUserDefaults.StandardUserDefaults.DictionaryForKey(PreferenceDictionaryKey);
            if (existingDictionary != null)
            {
                dictionary = (NSMutableDictionary)existingDictionary.MutableCopy();
            }

            return dictionary;
        }
    }
}
