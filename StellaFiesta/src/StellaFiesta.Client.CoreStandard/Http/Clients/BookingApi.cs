using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public class BookingApi : ApiBase, IBookingApi
    {
        public BookingApi(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        private string Route => $"{BaseUrl}/carbooking";

        public async Task<ResultBlock<List<CarBooking>>> GetBookingsAsync(
            CancellationToken token = default(CancellationToken))
        {
            try
            {
                token.ThrowIfCancellationRequested();

                var url = $"{Route}/bookings";
                var carTimes = await Executor.Get<IEnumerable<CarBooking>>(url);
                var result = new ResultBlock<List<CarBooking>>(true, carTimes.ToList());
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed getting bookings, ex: " + ex.Message);
                return new ResultBlock<List<CarBooking>>(false, null);
            }
        }

        public async Task<bool> MakingBookingAsync(
            CarBooking booking,
            CancellationToken token = default(CancellationToken))
        {
            try
            {
                token.ThrowIfCancellationRequested();

                var url = $"{Route}/makebooking";
                var didBook = await Executor.Post(url, booking);
                return didBook;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to send booking, ex: " + ex.Message);
            }

            return false;
        }

        public async Task<bool> RemoveBookingAsync(int id, CancellationToken token = default(CancellationToken))
        {
            try
            {
                token.ThrowIfCancellationRequested();

                var url = $"{Route}/bookings/{id}";
                var didRemoveBooking = await Executor.DeleteAsync(url);
                return didRemoveBooking;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to remove booking, ex: " + ex.Message);
            }

            return false;
        }
    }
}
