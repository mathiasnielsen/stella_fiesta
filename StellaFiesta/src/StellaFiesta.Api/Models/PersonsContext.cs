using System;
using Microsoft.EntityFrameworkCore;

namespace StellaFiesta.Api
{
    public class PersonsContext : DbContext
    {
        public PersonsContext(DbContextOptions<PersonsContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
