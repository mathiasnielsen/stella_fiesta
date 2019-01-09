using System;

namespace StellaFiesta.Client
{
    public static class NavigationParameterParser
    {
        public static DateTime StringToDateTime(string dateTimeAsString)
        {
            if (DateTime.TryParse(dateTimeAsString, out DateTime dateTime))
            {
                return dateTime;
            }

            throw new FormatException("String could not be parsed to DateTime");
        }
    }
}
