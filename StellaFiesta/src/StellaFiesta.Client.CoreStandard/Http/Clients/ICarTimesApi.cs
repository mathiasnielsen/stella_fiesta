using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StellaFiesta.Api;

namespace StellaFiesta.Client.CoreStandard
{
    public interface ICarTimesApi
    {
        Task<List<CarDay>> GetCarTimesAsync();
    }
}
