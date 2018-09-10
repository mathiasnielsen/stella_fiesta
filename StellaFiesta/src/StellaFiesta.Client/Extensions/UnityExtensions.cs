using Unity;
using Unity.Lifetime;

namespace StellaFiesta.Client
{
    public static class UnityExtensions
    {
        public static IUnityContainer RegisterSingleton<TInterface, TType>(this IUnityContainer container) where TType : TInterface
        {
            return container.RegisterType<TInterface, TType>(new ContainerControlledLifetimeManager());
        }
    }
}
