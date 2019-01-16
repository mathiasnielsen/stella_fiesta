using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public class CommonApi : ApiBase, ICommonApi
    {
        private const string Route = "common";

        public CommonApi(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<string> PingAsync()
        {
            var url = $"{BaseUrl}/{Route}/ping";
            var pingResult = await Executor.GetContent(url);
            return pingResult;
        }
    }
}
