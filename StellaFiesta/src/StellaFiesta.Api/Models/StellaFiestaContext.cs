using Microsoft.EntityFrameworkCore;

namespace StellaFiesta.Api
{
    public class StellaFiestaContext : DbContext
    {
        public StellaFiestaContext(DbContextOptions<StellaFiestaContext> options)
            : base(options)
        {
        }

        public DbSet<CarDay> CarDays { get; set; }

        public DbSet<Person> Persons { get; set; }
    }
}
