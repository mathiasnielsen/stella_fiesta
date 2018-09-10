using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;
using StellaFiesta.Client.Core;

namespace StellaFiesta.Client.CoreStandard
{
    public class CalendarViewModel : BindableViewModelBase
    {
        private readonly ICarTimesApi carTimesApi;

        private List<CarTime> carTimes;

        public CalendarViewModel(ICarTimesApi carTimesApi)
        {
            this.carTimesApi = carTimesApi;
        }

        public List<CarTime> CarTimes
        {
            get { return carTimes; }
            set { Set(ref carTimes, value); }
        }

        public override async Task OnViewInitialized(Dictionary<string, string> navigationParameters)
        {
            await RetrieveCarTimesAsync();
        }

        private async Task RetrieveCarTimesAsync()
        {
            CarTimes = await carTimesApi.GetCarTimesAsync();
        }
    }
}
