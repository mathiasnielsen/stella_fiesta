using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StellaFiesta.Api.Controllers;
using Xunit;

namespace StellaFiesta.Api.Tests
{
    public class CarTimesControllerTests
    {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
        private readonly CarTimesController _carTimesController;

        public CarTimesControllerTests()
        {
            var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var dbOption = new DbContextOptionsBuilder<StellaFiestaContext>()
            .UseSqlServer(connectionString)
            .Options;

            var context = new StellaFiestaContext(dbOption);
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<CarTimesController>();
            _carTimesController = new CarTimesController(context, logger);
        }

        [Fact]
        public async void CarTimesControllerTests_AddBooking()
        {
            var carBooking = new CarBooking
            {
                BookerName = "Mathias",
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1)
            };

            await _carTimesController.AddBookingAsync(carBooking);
        }

        [Fact]
        public async void CarTimesControllerTests_AddAndRemoveBooking()
        {
            var carBooking = new CarBooking
            {
                BookerName = "Mathias " + Guid.NewGuid(),
                BookingStartDate = DateTime.Now,
                BookingEndDate = DateTime.Now.AddDays(1)
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
#pragma warning restore CS1701 // Assuming assembly reference matches identity
    }
}
