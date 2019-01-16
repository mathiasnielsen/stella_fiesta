using System;
using System.Threading.Tasks;
using Xunit;
using Unity;

namespace StellaFiesta.Client.CoreStandard.Tests
{
    public class CommonApiTests : TestBase
    {
        [Fact]
        public async Task PingAsync()
        {
            var commonApi = Container.Resolve<ICommonApi>();
            var pingResult = await commonApi.PingAsync();

            Assert.True(pingResult != null);
        }
    }
}
