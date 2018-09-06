using System;
using Microsoft.EntityFrameworkCore;

namespace StellaFiesta.Api
{
    public interface IStellaFiestaContext
    {
        DbSet<CarTime> CarTimes { get; set; }

        DbSet<Person> Persons { get; set; }
    }
}
