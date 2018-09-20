using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public partial class MasterView : ContentPage
    {
        private View _mainContent;

        public MasterView()
        {
            InitializeComponent();
        }

        public View MainContent
        {
            get { return _mainContent; }

            set
            {
                if (_mainContent != value)
                {
                    _mainContent = value;
                    MainContentContainer.Children.Clear();
                    MainContentContainer.Children.Add(_mainContent);

                    OnPropertyChanged(nameof(MainContent));
                }
            }
        }
    }
}
