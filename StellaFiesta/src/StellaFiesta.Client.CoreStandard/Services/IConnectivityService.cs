using System;
namespace StellaFiesta.Client.CoreStandard
{
    public interface IConnectivityService
    {
        event EventHandler<bool> IsConnectedChanged;

        bool IsConnected { get; }
    }
}
