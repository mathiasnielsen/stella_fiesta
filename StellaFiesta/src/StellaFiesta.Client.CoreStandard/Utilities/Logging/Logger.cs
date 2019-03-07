using System;
using System.Diagnostics;

namespace StellaFiesta.Client.CoreStandard.Utilities.Logging
{
    public class Logger
    {
        private readonly string _nameOfLogger;

        public Logger(string nameOfLogger)
        {
            _nameOfLogger = nameOfLogger;
        }

        public void Info(string text)
        {
            Debug.WriteLine($"{_nameOfLogger}: {text}");
        }

        public void Exception(Exception ex, string text)
        {
            Debug.WriteLine($"{_nameOfLogger}: {text}, {Environment.NewLine}{ex.Message}");
        }
    }
}
