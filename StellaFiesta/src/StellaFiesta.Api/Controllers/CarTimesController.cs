using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarTimesController : Controller
    {
        private readonly CarTimesContext _context;

        public CarTimesController(CarTimesContext context)
        {
            _context = context;

            try
            {
                if (_context.CarTimes != null)
                {
                    if (_context.CarTimes.Count() == 0)
                    {
                    }
                }   
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed ctor CarTimes: " + ex.Message);
            }
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
