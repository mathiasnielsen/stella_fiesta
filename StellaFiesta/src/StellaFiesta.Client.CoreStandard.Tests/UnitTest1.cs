using System;
using Unity;
using Xunit;

namespace StellaFiesta.Client.CoreStandard.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var unityContainer = new UnityContainer();
            var bookingApi = unityContainer.Resolve<ICarTimesApi>();
        }
    }
}
