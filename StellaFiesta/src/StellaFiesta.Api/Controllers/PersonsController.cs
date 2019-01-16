using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api.Controllers
{
    [Route("api/persons")]
    public class PersonsController : Controller
    {
        private readonly StellaFiestaContext _context;

        public PersonsController(StellaFiestaContext context)
        {
            _context = context;
        }

        [HttpGet("persons")]
        public IEnumerable<string> GetPersons()
        {

            var allNames = _context.Persons.Select(x => x.LastName).ToList();
            return allNames;
        }
    }
}
