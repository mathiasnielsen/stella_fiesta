using System;
using Android.App;
using Android.Content;
using StellaFiesta.Client;
using StellaFiesta.Client.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// https://github.com/xamarin/Xamarin.Forms/blob/cceee9ded6c8cadb19eb547f72d03c6c14230058/Xamarin.Forms.Platform.Android/AppCompat/PickerRenderer.cs
[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace StellaFiesta.Client.Droid
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        private AlertDialog _dialog;

        public CustomDatePickerRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
                ////Control.Click
            }
        }
    }
}
