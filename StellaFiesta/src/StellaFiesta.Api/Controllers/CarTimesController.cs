using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api.Controllers
{
    [Route("api/carbooking")]
    public class CarTimesController : ControllerBase
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
                var bookings = _context.CarBookings;
                var carBookings = bookings.ToList();
                return carBookings;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed, ex:" + ex.Message);
                throw ex;
            }
        }

        [HttpPost("bookings")]
        public async Task<bool> AddBookingAsync([FromBody] CarBooking carDay)
        {
            try
            {
                _context.CarBookings.Add(carDay);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to post, ex:" + ex.Message);
                throw ex;
            }
        }

        [HttpDelete("bookings/{id}")]
        public async Task<bool> RemoveBookingAsync(int id)
        {
            try
            {
                var carBooking = _context.CarBookings.FirstOrDefault(x => x.ID == id);
                if (carBooking != null)
                {
                    _context.CarBookings.Remove(carBooking);
                    var result = await _context.SaveChangesAsync();
                    return result > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to post, ex:" + ex.Message);
                throw ex;
            }
        }
    }
}
