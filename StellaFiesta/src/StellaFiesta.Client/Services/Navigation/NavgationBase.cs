using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class NavigationBase
    {
        private Page _mainPage => Application.Current.MainPage;

        public NavigationBase()
        {
        }

        private Dictionary<string, Type> Pages { get; } = new Dictionary<string, Type>();

        protected void Configure(string key, Type pageType) => Pages[key] = pageType;

        public void DismissModal()
        {
            _mainPage.Navigation.PopModalAsync();
        }

        public void GoBack()
        {
            _mainPage.Navigation.PopAsync();
        }

        public void NavigateTo(
            string pageKey,
            Dictionary<string, string> parameter = null,
            HistoryBehavior historyBehavior = HistoryBehavior.Default)
        {
            if (Pages.TryGetValue(pageKey, out Type pageType))
            {
                var displayPage = (Page)Activator.CreateInstance(pageType);
                displayPage.SetNavigationArgs(parameter);

                if (historyBehavior == HistoryBehavior.ClearHistory)
                {
                    _mainPage.Navigation.InsertPageBefore(displayPage, _mainPage.Navigation.NavigationStack[0]);

                    // The transitions sucks when using this method.
                    ////_mainPage.Navigation.PopToRootAsync();

                    var existingPages = _mainPage.Navigation.NavigationStack.ToList();
                    for (int i = 1; i < existingPages.Count; i++)
                    {
                        ////_mainPage.Navigation.RemovePage(existingPages[i]);
                        _mainPage.Navigation.PopAsync();
                    }
                }
                else if (historyBehavior == HistoryBehavior.ClearTop)
                {
                    throw new NotImplementedException("Has not made clear top yet");
                }
                else
                {
                    _mainPage.Navigation.PushAsync(displayPage);
                }
            }
            else
            {
                throw new ArgumentException($"No such page: {pageKey}.", nameof(pageKey));
            }
        }

        public void PushModal(string pageKey)
        {
            if (Pages.TryGetValue(pageKey, out Type pageType))
            {
                var pageToDisplay = (Page)Activator.CreateInstance(pageType);
                _mainPage.Navigation.PushModalAsync(pageToDisplay);
            }
        }
    }
}
