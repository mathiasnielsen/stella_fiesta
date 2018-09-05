using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarTimesController : Controller
    {
        private readonly StellaFiestaContext _context;

        public CarTimesController(StellaFiestaContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var allNames = _context.Persons.Select(x => x.LastName).ToList();
            return allNames;
        }
    }
}
