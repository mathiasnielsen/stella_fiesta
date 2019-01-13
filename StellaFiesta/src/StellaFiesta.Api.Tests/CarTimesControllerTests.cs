using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StellaFiesta.Api.Controllers;
using Xunit;

namespace StellaFiesta.Api.Tests
{
    public class CarTimesControllerTests
    {
#pragma warning disable CS1701 // Assuming assembly reference matches identity
        [Fact]
        public async void CarTimesControllerTests_AddBooking()
        {
            var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var dbOption = new DbContextOptionsBuilder<StellaFiestaContext>()
            .UseSqlServer(connectionString)
            .Options;

            var context = new StellaFiestaContext(dbOption);
            var controller = new CarTimesController(context);

            var carBooking = new CarBooking();
            carBooking.BookerName = "Mathias";
            carBooking.BookingStartDate = DateTime.Now;
            carBooking.BookingEndDate = DateTime.Now.AddDays(1);

            await controller.AddBookingAsync(carBooking);
        }

        [Fact]
        public async void CarTimesControllerTests_AddAndRemoveBooking()
        {
            var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var dbOption = new DbContextOptionsBuilder<StellaFiestaContext>()
            .UseSqlServer(connectionString)
            .Options;

            var context = new StellaFiestaContext(dbOption);
            var controller = new CarTimesController(context);

            var carBooking = new CarBooking();
            carBooking.BookerName = "Mathias";
            carBooking.BookingStartDate = DateTime.Now;
            carBooking.BookingEndDate = DateTime.Now.AddDays(1);

            var addResult = await controller.AddBookingAsync(carBooking);
            var removeResult = await controller.RemoveBookingAsync(carBooking);
            IEnumerable<CarBooking> bookings = controller.GetAllBookings();

            var hasBooking = bookings.ToList().Exists(x => x.BookingStartDate == carBooking.BookingStartDate);
            Assert.True(hasBooking);
        }
#pragma warning restore CS1701 // Assuming assembly reference matches identity
    }
}
