using System;
namespace StellaFiesta.Client.CoreStandard
{
    public class LoadingScope : IDisposable
    {
        private readonly ILoadingManager loadingManager;
        private readonly Action completion;

        public LoadingScope(ILoadingManager loadingManager, Action completion)
        {
            this.loadingManager = loadingManager;
            this.loadingManager.BeginLoad();
            this.completion = completion;
        }

        public void Dispose()
        {
            completion?.Invoke();
            this.loadingManager.EndLoad();
        }
    }
}
