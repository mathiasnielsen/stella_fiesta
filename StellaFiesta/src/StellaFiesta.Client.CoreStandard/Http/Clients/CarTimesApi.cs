using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public class CarTimesApi : ICarTimesApi
    {
        private const string baseUrl = "http://stellafiesta.azurewebsites.net/api/";

        private readonly IHttpRequestExecutor executor;

        public CarTimesApi(IHttpClientFactory httpClientFactory)
        {
            executor = new HttpRequestExecutor(httpClientFactory);
        }

        public async Task<List<CarTime>> GetCarTimesAsync()
        {
            try
            {
                var carTimes = await executor.Get<List<CarTime>>(baseUrl + "cartimes");
                return carTimes;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed getting cartimes, ex: " + ex.Message);
            }
        }
    }
}
