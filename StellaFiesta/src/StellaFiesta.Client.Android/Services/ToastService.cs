using System;
using Android.App;
using Android.Widget;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Droid
{
    public class ToastService : IToastService
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
