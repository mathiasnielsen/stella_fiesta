using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class ViewBase : ContentPage
    {
        public ViewBase()
        {
            ControlTemplate = (ControlTemplate)Application.Current.Resources["MainPageTemplate"];
        }
    }
}
