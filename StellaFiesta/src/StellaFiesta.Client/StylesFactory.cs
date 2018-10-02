using System;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public static class StylesFactory
    {
        public static ResourceDictionary GenerateStyles(ResourceDictionary currentResourceDictionary)
        {
            var resourceDictionary = currentResourceDictionary ?? new ResourceDictionary();

            CreateNavigationStyles(resourceDictionary);
            CreateEntryStyles(resourceDictionary);
            CreateButtonStyles(resourceDictionary);

            return resourceDictionary;
        }

        private static void CreateNavigationStyles(ResourceDictionary resourceDictionary)
        {
            var navigationStyle = new Style(typeof(NavigationPage))
            {
                Setters =
                {
                    new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = (Color)resourceDictionary["BrandColor"] }
                }
            };

            resourceDictionary.Add(navigationStyle);
        }

        private static void CreateButtonStyles(ResourceDictionary resourceDictionary)
        {
            var buttonStyle = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter { Property = Button.TextColorProperty, Value = Color.Orange }
                }
            };

            resourceDictionary.Add(buttonStyle);
        }

        private static void CreateEntryStyles(ResourceDictionary resourceDictionary)
        {
            var entryStyle = new Style(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = Entry.TextColorProperty, Value = Color.Blue }
                }
            };

            resourceDictionary.Add(entryStyle);
        }
    }
}
