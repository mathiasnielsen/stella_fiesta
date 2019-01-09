using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api.Controllers
{
    [Route("api/carbooking")]
    public class CarTimesController : Controller
    {
        private readonly StellaFiestaContext _context;

        public CarTimesController(StellaFiestaContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("bookings")]
        public IEnumerable<CarBooking> Get()
        {
            try
            {
                var carDays = _context.CarBookings;
                var carBookings = carDays.ToList();
                return carDays;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed, ex:" + ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public async Task AddBookingAsync(CarBooking carDay)
        {
            try
            {
                await _context.CarBookings.AddAsync(carDay);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to post, ex:" + ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        public async Task AddBookingAsync(CarBooking carDay)
        {
            try
            {
                await _context.CarBookings.AddAsync(carDay);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to post, ex:" + ex.Message);
                throw ex;
            }
        }
    }
}
