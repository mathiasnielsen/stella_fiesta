using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UIKit;

namespace StellaFiesta.Client.iOS
{
    public class CustomUIPickerViewModel : UIPickerViewModel
    {
        private const int YearComponentValue = 0;
        private const int MonthComponentValue = 1;
        private const int MonthsCount = 12;

        private readonly UITextField textField;
        private readonly UIPickerView pickerView;

        private List<int> years;
        private int selectedYearIndex;
        private int selectedMonthIndex;

        public CustomUIPickerViewModel(UITextField textField, UIPickerView pickerView)
        {
            this.textField = textField;
            this.pickerView = pickerView;

            UpdateYears(DateTime.MinValue, DateTime.MaxValue);
        }

        public void UpdateYears(DateTime minDateTime, DateTime maxDateTime)
        {
            years = new List<int>();
            var yearDelta = maxDateTime.Year - minDateTime.Year;
            for (int i = 0; i < yearDelta; i++)
            {
                years.Add(minDateTime.Year + i);
            }
        }

        public void SetDate(DateTime dateTime)
        {
            selectedYearIndex = years.FindIndex(x => x == dateTime.Year);
            selectedMonthIndex = dateTime.Month - 1;

            pickerView.Select(selectedYearIndex, YearComponentValue, true);
            pickerView.Select(selectedMonthIndex, MonthComponentValue, true);

            UpdateSelectedTextFieldValue();
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 2;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            if (component == YearComponentValue)
            {
                return years.Count;
            }

            return MonthsCount;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == YearComponentValue)
            {
                var year = years[(int)row];
                return year.ToString();
            }
            else
            {
                var monthInText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)row + 1);
                return monthInText;
            }
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            if (component == YearComponentValue)
            {
                selectedYearIndex = (int)row;
            }
            else
            {
                selectedMonthIndex = (int)row;
            }

            UpdateSelectedTextFieldValue();
        }

        private void UpdateSelectedTextFieldValue()
        {
            var year = years[selectedYearIndex];
            var monthInText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)selectedMonthIndex + 1);
            textField.Text = $"{year} {monthInText}";
        }
    }
}
