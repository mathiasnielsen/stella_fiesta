using System;
using Microsoft.EntityFrameworkCore;
using StellaFiesta.Api.Controllers;
using Xunit;

namespace StellaFiesta.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
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
    }
}
