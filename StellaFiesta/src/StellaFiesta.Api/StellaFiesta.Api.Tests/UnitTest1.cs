using System;
using Microsoft.EntityFrameworkCore;
using StellaFiesta.Api.Controllers;
using Xunit;

namespace StellaFiesta.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CarTimesController()
        {
            var context = new StellaFiestaContextMock();
            var carTimeController = new CarTimesController(context);
        }

        private class StellaFiestaContextMock : IStellaFiestaContext
        {
            public StellaFiestaContextMock()
            {
            }

            public DbSet<CarTime> CarTimes { get; set; }

            public DbSet<Person> Persons { get; set; }
        }
    }
}
