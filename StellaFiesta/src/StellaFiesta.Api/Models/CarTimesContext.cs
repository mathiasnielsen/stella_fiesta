using Microsoft.EntityFrameworkCore;

namespace StellaFiesta.Api
{
    public class CarTimesContext : DbContext
    {
        public CarTimesContext(DbContextOptions<CarTimesContext> options)
            : base(options)
        {
        }

        public DbSet<CarTime> CarTimes { get; set; }
    }
}
