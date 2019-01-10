using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard.Utilities;

namespace StellaFiesta.Client.CoreStandard
{
    public class BookingViewModel : BindableViewModelBase
    {
        public const string BookingDateInTicksParameterKey = nameof(BookingDateInTicksParameterKey);

        private readonly INavigationService navigationService;

        private DateTime _bookingDate;
        private string _dateTitle;

        public BookingViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            AcceptBookingCommand = new RelayCommand(AcceptBooking);
        }

        public RelayCommand AcceptBookingCommand { get; }

        public string DateTitle
        {
            get { return _dateTitle; }
            set { Set(ref _dateTitle, value); }
        }

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            _bookingDate = NavigationParameterParser.StringDateTicksToDateTime(
                 navigationParameters[BookingDateInTicksParameterKey]);

            DateTitle = GetDateInText(_bookingDate);

            return base.OnViewInitialized(navigationParameters);
        }

        private string GetDateInText(DateTime dateTime)
        {
            var day = dateTime.GetDayNumberInMonth();
            var weekdayName = dateTime.GetWeekdayName();
            var month = dateTime.GetMonthName();
            var year = dateTime.GetYear();

            return $"{day} ({weekdayName}), {month}, {year}";
        }

        private void AcceptBooking()
        {
            navigationService.GoBack();
        }
    }
}
