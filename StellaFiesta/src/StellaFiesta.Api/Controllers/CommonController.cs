using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api
{
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        private const string StartTimeStamp = nameof(StartTimeStamp);

        [HttpGet]
        public string Get()
        {
            // This is called when the server starts.
            return "It is up and running";
        }

        [HttpGet("ping")]
        public string Ping()
        {
            return $"You pinged me!";
        }

        [HttpGet("save_in_session")]
        public void TestHttpContextSave()
        {
            try
            {
                var dateTimeInString = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                HttpContext.Session.SetString(StartTimeStamp, dateTimeInString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to save string in session, ex: " + ex.Message);
                throw;
            }
        }

        [HttpGet("retrieve_from_session")]
        public void HttpContextRetrieve()
        {
            try
            {
                var savedText = HttpContext.Session.GetString(StartTimeStamp);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to retrieve string from session, ex: " + ex.Message);
                throw;
            }
        }
    }
}
