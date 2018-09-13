using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public class CarTimesApi : ICarTimesApi
    {
        private const string baseUrl = "http://stellafiesta.azurewebsites.net/api/carbooking/";

        private readonly IHttpRequestExecutor executor;

        public CarTimesApi(IHttpClientFactory httpClientFactory)
        {
            executor = new HttpRequestExecutor(httpClientFactory);
        }

        public async Task<List<CarBooking>> GetCarTimesAsync()
        {
            try
            {
                var carTimes = await executor.Get<List<CarBooking>>(baseUrl + "bookings");
                return carTimes;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed getting cartimes, ex: " + ex.Message);
            }
        }
    }
}
