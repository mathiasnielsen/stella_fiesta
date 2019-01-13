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
        private const string LocalBaseUrl = "http://localhost:32264/api/carbooking/";
        private const string AzureBaseUrl = "http://stellafiesta.azurewebsites.net/api/carbooking/";
        private const string BaseUrl = LocalBaseUrl;
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
                var carTimes = await executor.Get<List<CarBooking>>(BaseUrl + "bookings");
                return carTimes;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed getting cartimes, ex: " + ex.Message);
            }
        }

        public async Task<bool> MakingBookingAsync(CarBooking booking)
        {
            try
            {
                var didBook = await executor.Post(BaseUrl + "bookings", booking);
                return didBook;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to send booking, ex: " + ex.Message);
                ////throw new Exception("Failed sending booking, ex: " + ex.Message);
            }

            return false;
        }

        public async Task<bool> RemoveBookingAsync(int id)
        {
            try
            {
                var didRemoveBooking = await executor.DeleteAsync($"{BaseUrl}bookings/{id}");
                return didRemoveBooking;
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
