using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EngageVoice
{
    public static class Utils
    {
        public static IEnumerable<(string name, object value)> GetPairs(params object[] objs)
        {
            return objs.Select(obj => obj.GetType().GetFields().Select(f => (name: f.Name, value: f.GetValue(obj)))
                .Concat(obj.GetType().GetProperties().Select(p => (name: p.Name, value: p.GetValue(obj))))
                .Where(t => t.value != null)).SelectMany(p => p);
        }
        public static string FormatHttpMessage(HttpResponseMessage httpResponseMessage,
            HttpRequestMessage httpRequestMessage)
        {
            var message = $"Response:\n{httpResponseMessage.ToString()}";
            if (httpResponseMessage.Content != null)
            {
                message += $"\nContent: {httpResponseMessage.Content.ReadAsStringAsync().Result}";
            }

            message += $"\n\nRequest:\n{httpRequestMessage.ToString()}";
            if (httpRequestMessage.Content != null)
            {
                try
                {
                    message += $"\nContent: {httpRequestMessage.Content.ReadAsStringAsync().Result}";
                }
                catch (ObjectDisposedException)
                {
                    message +=
                        $"\nContent: <content has been disposed by HttpClient: https://github.com/dotnet/corefx/issues/1794>";
                }
            }

            return message;
        }
    }
}
