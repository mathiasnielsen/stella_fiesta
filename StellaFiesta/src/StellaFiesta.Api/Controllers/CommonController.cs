using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StellaFiesta.Api
{
    [Route("api/[controller]")]
    public class CommonController : Controller
    {
        private const string StartTimeStamp = nameof(StartTimeStamp);

        // GET api/values
        [HttpGet]
        public string Get()
        {
            try
            {
                // Requires: using Microsoft.AspNetCore.Http;
                var dateTimeInString = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                HttpContext.Session.SetString(StartTimeStamp, dateTimeInString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to set timestamp in session, ex: " + ex.Message);
                throw;
            }

            return "It is up and running";
        }

        [HttpGet("ping")]
        public string Ping()
        {
            ////var startTimeStamp = HttpContext.Session.GetString(StartTimeStamp);
            ////return $"You pinged me! Server startet: {startTimeStamp}";

            return $"You pinged me!";
        }

        [HttpGet("testing_httpContext")]
        public string TestHttpContext()
        {
            try
            {
                var dateTimeInString = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                HttpContext.Session.SetString(StartTimeStamp, dateTimeInString);

                var startTimeStamp = HttpContext.Session.GetString(StartTimeStamp);
                return $"Test for httpContext: {startTimeStamp}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to ping, ex: " + ex.Message);
                throw;
            }
        }
    }
}
