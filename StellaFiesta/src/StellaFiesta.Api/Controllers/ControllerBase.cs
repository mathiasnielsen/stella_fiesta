using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StellaFiesta.Api
{
    public abstract class ControllerBase : Controller
    {
        protected string SerializeStructResponse<TResponse>(TResponse response)
            where TResponse : class
        {
            var serializedResponse = JsonConvert.SerializeObject(response);
            return serializedResponse;
        }
    }
}
