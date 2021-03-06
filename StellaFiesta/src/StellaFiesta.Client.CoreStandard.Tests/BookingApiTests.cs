using System;
using System.Linq;
using System.Threading.Tasks;
using StellaFiesta.Api;
using Unity;
using Xunit;

namespace StellaFiesta.Client.CoreStandard.Tests
{
    public class BookingApiTests : TestBase
    {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
        [Fact]
        public async Task BookingApiTests_GetBookings()
        {
            var bookingApi = Container.Resolve<IBookingApi>();
            var bookings = await bookingApi.GetBookingsAsync();
            Assert.True(bookings.Any());
        }

        [Fact]
        public async Task BookingApi_MakeABooking_DidBook()
        {
            var bookingApi = Container.Resolve<IBookingApi>();
            var carBooking = new CarBooking()
            {
                BookerName = "Gabriella" + Guid.NewGuid(),
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1),
            };

            var didBook = await bookingApi.MakingBookingAsync(carBooking);
            var bookings = await bookingApi.GetBookingsAsync();
            var didFindBooking = bookings.Exists(
                x => x.BookerName == carBooking.BookerName);

            Assert.True(didBook);
            Assert.True(didFindBooking);
        }

        [Fact]
        public async Task BookingApi_RemoveABooking_DidBookAndRemoveItAgain()
        {
            var bookingApi = Container.Resolve<IBookingApi>();
            var carBooking = new CarBooking()
            {
                BookerName = "Gabriella" + Guid.NewGuid(),
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1),
            };

            var didBook = await bookingApi.MakingBookingAsync(carBooking);
            var bookings = await bookingApi.GetBookingsAsync();
            var newBooking = bookings.FirstOrDefault(
                x => x.BookerName == carBooking.BookerName);

            Assert.True(didBook);
            Assert.True(newBooking != null);

            var didRemoveBooking = await bookingApi.RemoveBookingAsync(newBooking.ID);
            var bookingsAfterRemove = await bookingApi.GetBookingsAsync();
            var newBookingStillExists = bookingsAfterRemove.Exists(
                x => x.BookerName == carBooking.BookerName);

            Assert.True(didRemoveBooking);
            Assert.True(newBookingStillExists == false);
        }
#pragma warning restore CS1701 // Assuming assembly reference matches identity
    }
}
