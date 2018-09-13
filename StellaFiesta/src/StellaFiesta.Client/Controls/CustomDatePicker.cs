using System;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class CustomDatePicker : DatePicker
    {
        public CustomDatePicker()
        {
        }

        public event EventHandler<DateTime> FinishedSelection;

        public void RaiseFinishedSelection(DateTime dateTime)
        {
            FinishedSelection?.Invoke(this, dateTime);
        }

        public static readonly BindableProperty NumberOfComponentsProperty = BindableProperty.Create(
            propertyName: nameof(NumberOfComponents),
            returnType: typeof(int),
            declaringType: typeof(CustomDatePicker),
            defaultValue: default(int));

        public int NumberOfComponents
        {
            get { return (int)GetValue(NumberOfComponentsProperty); }
            set { SetValue(NumberOfComponentsProperty, value); }
        }
    }
}
