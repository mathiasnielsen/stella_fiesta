using System;
using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public interface ICommonApi
    {
        Task<string> PingAsync();
    }
}
