using System;
namespace StellaFiesta.Client.CoreStandard
{
    public class StorageServiceBase
    {
        protected void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key is invalid");
            }
        }
    }
}
