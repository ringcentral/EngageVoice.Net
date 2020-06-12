using System;
using System.Net.Http;

namespace EngageVoice
{
    public class RestException : Exception
    {
        public readonly HttpResponseMessage HttpResponseMessage;

        public RestException(HttpResponseMessage httpResponseMessage, HttpRequestMessage httpRequestMessage)
            : base(Utils.FormatHttpMessage(httpResponseMessage, httpRequestMessage))
        {
            HttpResponseMessage = httpResponseMessage;
        }
    }
}