using System;
using System.Net.Http;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}
