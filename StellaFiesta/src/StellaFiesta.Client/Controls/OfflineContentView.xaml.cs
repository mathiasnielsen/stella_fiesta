using System;
using Xamarin.Forms;

namespace StellaFiesta.Client.Controls
{
    public partial class OfflineContentView : ContentView
    {
        public OfflineContentView()
        {
            InitializeComponent();

            IsVisible = false;
        }

        public static BindableProperty IsInOfflineStateProperty =
        BindableProperty.Create(
            nameof(IsInOfflineState),
            typeof(bool),
            typeof(OfflineContentView),
            defaultValue: false,
            propertyChanged: OnIsInOfflineStateChanged);

        public bool IsInOfflineState
        {
            get { return (bool)GetValue(IsInOfflineStateProperty); }
            set { SetValue(IsInOfflineStateProperty, value); }
        }

        private static void OnIsInOfflineStateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (OfflineContentView)bindable;
            var isInOfflineState = (bool)newValue;

            control.IsVisible = isInOfflineState;
        }
    }
}
