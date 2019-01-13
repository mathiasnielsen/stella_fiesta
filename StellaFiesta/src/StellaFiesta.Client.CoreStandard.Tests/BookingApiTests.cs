using System;
using System.Linq;
using System.Threading.Tasks;
using StellaFiesta.Api;
using Unity;
using Xunit;

namespace StellaFiesta.Client.CoreStandard.Tests
{
    public class BookingApiTests
    {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
        [Fact]
        public async Task BookingApiTests_GetBookings()
        {
            var container = CreateUnityContainer();
            var bookingApi = container.Resolve<ICarTimesApi>();
            var bookings = await bookingApi.GetCarTimesAsync();
            Assert.True(bookings.Any());
        }

        [Fact]
        public async Task BookingApi_MakeABooking_DidBook()
        {
            var container = CreateUnityContainer();
            var bookingApi = container.Resolve<ICarTimesApi>();

            var carBooking = new CarBooking()
            {
                BookerName = "Gabriella" + Guid.NewGuid(),
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1),
            };

            var didBook = await bookingApi.MakingBookingAsync(carBooking);
            var bookings = await bookingApi.GetCarTimesAsync();
            var didFindBooking = bookings.Exists(
                x => x.BookerName == carBooking.BookerName);

            Assert.True(didBook);
            Assert.True(didFindBooking);
        }

        [Fact]
        public async Task BookingApi_RemoveABooking_DidBookAndRemoveItAgain()
        {
            var container = CreateUnityContainer();
            var bookingApi = container.Resolve<ICarTimesApi>();

            var carBooking = new CarBooking()
            {
                BookerName = "Gabriella" + Guid.NewGuid(),
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1),
            };

            var didBook = await bookingApi.MakingBookingAsync(carBooking);
            var bookings = await bookingApi.GetCarTimesAsync();
            var newBooking = bookings.FirstOrDefault(
                x => x.BookerName == carBooking.BookerName);

            Assert.True(didBook);
            Assert.True(newBooking != null);

            var didRemoveBooking = await bookingApi.RemoveBookingAsync(newBooking.ID);
            var bookingsAfterRemove = await bookingApi.GetCarTimesAsync();
            var newBookingStillExists = bookingsAfterRemove.Exists(
                x => x.BookerName == carBooking.BookerName);

            Assert.True(didRemoveBooking);
            Assert.True(newBookingStillExists == false);
        }

        private UnityContainer CreateUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterSingleton<ICarTimesApi, CarTimesApi>();
            unityContainer.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();

            return unityContainer;
        }
#pragma warning restore CS1701 // Assuming assembly reference matches identity
    }
}
