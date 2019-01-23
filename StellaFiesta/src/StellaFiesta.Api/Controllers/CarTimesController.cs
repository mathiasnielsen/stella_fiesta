using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StellaFiesta.Api.Controllers
{
    [Route("api/carbooking")]
    public class CarTimesController : ControllerBase
    {
        private readonly StellaFiestaContext _context;
        private readonly ILogger _logger;

        public CarTimesController(StellaFiestaContext context, ILogger<CarTimesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET api/values
        [HttpGet("bookings")]
        public IEnumerable<CarBooking> GetAllBookings()
        {
            try
            {
                _logger.LogInformation($"Retrieving all bookings");
                var bookings = _context.CarBookings;
                var carBookings = bookings.ToList();
                return carBookings;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed, ex:" + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("makebooking")]
        public async Task<bool> AddBookingAsync([FromBody] CarBooking carDay)
        {
            try
            {
                _logger.LogInformation($"Started adding booking, bookerName: {carDay?.BookerName}");
                _context.CarBookings.Add(carDay);
                _logger.LogInformation($"Added, bookerName: {carDay?.BookerName}");
                var result = await _context.SaveChangesAsync();
                _logger.LogInformation($"Result = {result}, bookerName: {carDay?.BookerName}");
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Failed to post, ex:" + ex.Message);
                throw;
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
