using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;
using StellaFiesta.Client.CoreStandard.Utilities;

namespace StellaFiesta.Client.CoreStandard
{
    public class BookingDetailsViewModel : BindableViewModelBase
    {
        public const string BookingParameterKey = nameof(BookingParameterKey);

        private readonly ICarTimesApi carTimesApi;
        private readonly INavigationService navigationService;
        private readonly IAuthenticationService authenticationService;

        private CarBooking booking;

        public BookingDetailsViewModel(
            INavigationService navigationService,
            ICarTimesApi carTimesApi,
            IAuthenticationService authenticationService)
        {
            this.navigationService = navigationService;
            this.carTimesApi = carTimesApi;
            this.authenticationService = authenticationService;

            CancelBookingCommand = new RelayCommand(CancelBooking);
        }

        public RelayCommand CancelBookingCommand { get; }

        public override Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            booking = NavigationParameterParser.JsonConvertParameter<CarBooking>(
                navigationParameters[BookingParameterKey]);

            return base.OnViewInitialized(navigationParameters);
        }

        private async void CancelBooking()
        {
            using (LoadingManager.CreateLoadingScope())
            {
                var user = await authenticationService.GetProfileAsync();
                await carTimesApi.RemoveBookingAsync(booking.ID);
            }
        }
    }
}
