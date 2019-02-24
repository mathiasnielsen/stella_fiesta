using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, Dictionary<string, string>> arguments = new ConditionalWeakTable<Page, Dictionary<string, string>>();

        public static Dictionary<string, string> GetNavigationArgs(this Page page)
        {
            arguments.TryGetValue(page, out Dictionary<string, string> argument);
            return argument;
        }

        public static void SetNavigationArgs(this Page page, Dictionary<string, string> args)
        {
            arguments.Add(page, args);
        }
    }
}
