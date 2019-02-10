using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IBookingApi
    {
        Task<ResultBlock<List<CarBooking>>> GetBookingsAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> MakingBookingAsync(CarBooking booking, CancellationToken token = default(CancellationToken));

        Task<bool> RemoveBookingAsync(int id, CancellationToken token = default(CancellationToken));
    }
}
