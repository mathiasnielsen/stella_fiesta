using System;

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
    }
}
