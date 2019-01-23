using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public class CarTimesApi : ApiBase, ICarTimesApi
    {
        private string route => $"{BaseUrl}/carbooking";

        public CarTimesApi(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<List<CarBooking>> GetCarTimesAsync()
        {
            try
            {
                var url = $"{route}/bookings";
                var carTimes = await Executor.Get<IEnumerable<CarBooking>>(url);
                return carTimes.ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed getting cartimes, ex: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> MakingBookingAsync(CarBooking booking)
        {
            try
            {
                var url = $"{route}/makebooking";
                var didBook = await Executor.Post(url, booking);
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
                var url = $"{route}/bookings/{id}";
                var didRemoveBooking = await Executor.DeleteAsync(url);
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
