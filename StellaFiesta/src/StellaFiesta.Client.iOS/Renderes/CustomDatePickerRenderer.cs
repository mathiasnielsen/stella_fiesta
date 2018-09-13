using System;
using System.ComponentModel;
using StellaFiesta.Client;
using StellaFiesta.Client.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// Read stuff here:
// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/listview
[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        private CustomUIPickerViewModel customDatePickerViewModel;

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe here!
            }

            if (e.NewElement != null)
            {
                // Subscribe here!

                Control.BorderStyle = UIKit.UITextBorderStyle.Line;

                var customPicker = new CustomUIPickerView();
                customDatePickerViewModel = new CustomUIPickerViewModel(Control, customPicker);
                customPicker.Model = customDatePickerViewModel;
                Control.InputView = customPicker;

                var toolbar = new UIToolbar();
                toolbar.BarStyle = UIBarStyle.BlackOpaque;
                toolbar.SizeToFit();
                toolbar.BarTintColor = UIColor.Black;
                toolbar.Translucent = true;

                var flexButton = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
                var doneButton = new UIBarButtonItem(
                    "Done",
                    UIBarButtonItemStyle.Bordered,
                    DoneButtonPressed);

                toolbar.SetItems(new[] { flexButton, doneButton }, true);

                Control.InputAccessoryView = toolbar;

                customDatePickerViewModel.SetDate(DateTime.Now);
            }
        }

        private void DoneButtonPressed(object sender, EventArgs e)
        {
            Control.ResignFirstResponder();
            ////DropdownValueSelected?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(Element.MinimumDate) || e.PropertyName == nameof(Element.MaximumDate))
            {
                var formsControl = Element as CustomDatePicker;
                var minDate = formsControl.MinimumDate;
                var maxDate = formsControl.MaximumDate;
                ////customDatePickerViewModel.UpdateYears(minDate, maxDate);
            }
        }
    }
}
