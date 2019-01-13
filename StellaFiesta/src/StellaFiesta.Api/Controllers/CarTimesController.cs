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
        public IEnumerable<CarBooking> GetAllBookings()
        {
            try
            {
                var carDays = _context.CarBookings;
                var carBookings = carDays.ToList();
                return carBookings;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed, ex:" + ex.Message);
                throw ex;
            }
        }

        [HttpPost("bookings")]
        public async Task<int> AddBookingAsync(CarBooking carDay)
        {
            try
            {
                _context.CarBookings.Add(carDay);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to post, ex:" + ex.Message);
                throw ex;
            }
        }

        [HttpDelete("bookings")]
        public async Task<int> RemoveBookingAsync(CarBooking carDay)
        {
            try
            {
                _context.CarBookings.Remove(carDay);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to post, ex:" + ex.Message);
                throw ex;
            }
        }
    }
}
