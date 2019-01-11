using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public class CarTimesApi : ICarTimesApi
    {
        private const string baseUrl = "http://stellafiesta.azurewebsites.net/api/carbooking/";
        private const string MediaType = "application/json";

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

        public async Task<bool> SendBookingAsync(CarBooking booking)
        {
            try
            {
                var result = await executor.Post<CarBooking, CarBooking>(baseUrl + "bookings", booking);
                return result != null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to send booking, ex: " + ex.Message);
                ////throw new Exception("Failed sending booking, ex: " + ex.Message);
            }

            return false;
        }
    }
}
