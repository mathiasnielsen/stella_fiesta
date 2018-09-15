using System;
using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IFacebookService
    {
        Task<bool> LogInAsync();
    }
}
