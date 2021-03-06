﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IHttpRequestExecutor
    {
        Task<TResponse> Put<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> bodyParameter)
            where TResponse : class;

        Task<bool> Post<TContent>(string url, TContent bodyParameter)
            where TContent : class;

        Task<TResponse> Post<TContent, TResponse>(string url, TContent bodyParameter)
            where TResponse : class
            where TContent : class;

        Task<bool> DeleteAsync(string url);

        /// <summary>
        /// Get class objects
        /// </summary>
        Task<TResponse> Get<TResponse>(string url)
            where TResponse : class;

        /// <summary>
        /// Use this to retrieve string data.
        /// </summary>
        Task<string> GetContent(string url);
    }
}
