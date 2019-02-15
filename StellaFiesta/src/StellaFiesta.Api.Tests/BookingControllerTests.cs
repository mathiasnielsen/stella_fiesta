using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StellaFiesta.Api.Controllers;
using Xunit;

namespace StellaFiesta.Api.Tests
{
    public class BookingControllerTests
    {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
        private readonly BookingController _carTimesController;

        public BookingControllerTests()
        {
            ////var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var dbOption = new DbContextOptionsBuilder<StellaFiestaContext>()
                .UseInMemoryDatabase("BookingTestDatabase")
                .Options;

            var context = new StellaFiestaContext(dbOption);
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<BookingController>();
            _carTimesController = new BookingController(context, logger);
        }

        [Fact]
        public void BookingControllerTests_GetBookings()
        {
            var bookings = _carTimesController.GetAllBookings();
            Assert.True(bookings != null);
        }

        [Fact]
        public async void BookingControllerTests_AddBooking()
        {
            var carBooking = new CarBooking
            {
                BookerName = "Mathias",
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1),
                BookerId = "1234",
            };

            var didBook = await _carTimesController.AddBookingAsync(carBooking);
            Assert.True(didBook);
        }

        [Fact]
        public async void BookingControllerTests_AddAndRemoveBooking()
        {
            var carBooking = new CarBooking
            {
                BookerName = "Mathias " + Guid.NewGuid(),
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1),
                BookerId = "1234",
            };

            var addResult = await _carTimesController.AddBookingAsync(carBooking);
            var allBookings = _carTimesController.GetAllBookings();
            var carBookingId = allBookings.FirstOrDefault(x => x.BookerName == carBooking.BookerName).ID;
            var removeResult = await _carTimesController.RemoveBookingAsync(carBookingId);
            var updatedAllBookings = _carTimesController.GetAllBookings();
            var oldBookingWhichShouldBeNull = updatedAllBookings.FirstOrDefault(x => x.BookerName == carBooking.BookerName);
            IEnumerable<CarBooking> bookings = _carTimesController.GetAllBookings();

            var hasBooking = bookings.ToList().Exists(x => x.BookingStartDate == carBooking.BookingStartDate);

            Assert.True(addResult);
            Assert.True(carBookingId >= 0);
            Assert.True(removeResult);
            Assert.True(oldBookingWhichShouldBeNull == null);
        }

        [Fact]
        public async void BookingControllerTests_TwoBookingsCannotBeMade()
        {
            var bookingStartData = DateTime.Now;
            var booking1 = new CarBooking
            {
                BookerName = "Mathias1",
                BookingStartDate = bookingStartData,
                BookingEndDate = DateTime.Now.AddDays(1),
                BookerId = "1234",
            };

            var booking2 = new CarBooking
            {
                BookerName = "Mathias2",
                BookingStartDate = bookingStartData,
                BookingEndDate = DateTime.Now.AddDays(1),
                BookerId = "1234",
            };

            var didBook1 = false;
            var didBook2 = false;

            Parallel.For(
                0,
                2,
                async (index) =>
                {
                    if (index == 0)
                    {
                        didBook1 = await _carTimesController.AddBookingAsync(booking1);
                    }
                    else
                    {
                        didBook2 = await _carTimesController.AddBookingAsync(booking2);
                    }
                });

            Assert.True(didBook1 != didBook2);
        }
#pragma warning restore CS1701 // Assuming assembly reference matches identity
    }
}
