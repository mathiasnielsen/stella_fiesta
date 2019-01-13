using System;
using Newtonsoft.Json;

namespace StellaFiesta.Client.CoreStandard.Utilities
{
    public static class NavigationParameterParser
    {
        public static DateTime StringDateTicksToDateTime(string dateTimeAsString)
        {
            if (long.TryParse(dateTimeAsString, out long dateTimeAsTicks))
            {
                return new DateTime(dateTimeAsTicks);
            }

            throw new FormatException("String could not be parsed to DateTime");
        }

        public static TParameterType JsonConvertParameter<TParameterType>(string parameter)
            where TParameterType : class
        {
            try
            {
                var content = JsonConvert.DeserializeObject<TParameterType>(parameter);
                return content;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to parse parameter to {typeof(TParameterType)}, ex: {ex.Message}");
                throw;
            }
        }
    }
}
