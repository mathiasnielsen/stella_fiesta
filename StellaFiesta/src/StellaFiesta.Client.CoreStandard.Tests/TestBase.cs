using Unity;

namespace StellaFiesta.Client.CoreStandard.Tests
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            Container = CreateUnityContainer();
        }

        protected UnityContainer Container { get; private set; }

        private UnityContainer CreateUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterSingleton<IBookingApi, BookingApi>();
            unityContainer.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();
            unityContainer.RegisterSingleton<ICommonApi, CommonApi>();

            return unityContainer;
        }
    }
}
