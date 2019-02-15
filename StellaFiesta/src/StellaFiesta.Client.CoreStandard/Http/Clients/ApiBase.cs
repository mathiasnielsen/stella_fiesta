using System;

namespace StellaFiesta.Client.CoreStandard
{
    public abstract class ApiBase
    {
        private const string ApiBaseUrl = "https://stellafiesta.azurewebsites.net/api";
        private const string LocalBaseUrl = "http://localhost:32264/api";

        protected ApiBase(IHttpClientFactory httpClientFactory)
        {
            Executor = new HttpRequestExecutor(httpClientFactory);
        }

        protected string BaseUrl => ApiBaseUrl;

        protected string MediaType => "application/json";

        protected IHttpRequestExecutor Executor { get; }
    }
}
