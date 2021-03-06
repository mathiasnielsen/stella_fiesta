﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StellaFiesta.Api
{
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        private const string StartTimeStamp = nameof(StartTimeStamp);

        private readonly ILogger<CommonController> _logger;

        public CommonController(ILogger<CommonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            // This, we are able to find in Portal.Azure
            _logger.LogInformation($"This is a log that i made... but can you find me?");

            // This is nope... 
            Trace.WriteLine("Is this in application insights?");

            // This is called when the server starts.
            return "It is up and running";
        }

        [HttpGet("ping")]
        public string Ping()
        {
            return $"You pinged me!";
        }

        [HttpGet("save_in_session")]
        public string TestHttpContextSave()
        {
            try
            {
                var dateTimeInString = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
                HttpContext.Session.SetString(StartTimeStamp, dateTimeInString);
                return dateTimeInString;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to save string in session, ex: " + ex.Message);
                throw;
            }
        }

        [HttpGet("retrieve_from_session")]
        public string HttpContextRetrieve()
        {
            try
            {
                var savedText = HttpContext.Session.GetString(StartTimeStamp);
                return savedText;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to retrieve string from session, ex: " + ex.Message);
                throw;
            }
        }
    }
}
