using System;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client
{
    public class ConnectivityService : IConnectivityService
    {
        public ConnectivityService()
        {
            Initialize();
        }

        public bool IsConnected => CrossConnectivity.Current.IsConnected;

        public event EventHandler<bool> IsConnectedChanged;

        private void Initialize()
        {
            CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
        }

        private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsConnectedChanged?.Invoke(this, e.IsConnected);
        }
    }
}
