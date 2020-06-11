using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EngageVoice
{
    public class EngageVoice
    {
        public static HttpClient httpClient = new HttpClient();
        
        public string server;

        public EngageVoiceToken token;
        
        public EngageVoice(string server = "https://engage.ringcentral.com")
        {
            this.server = server;
        }
        
        public async Task<EngageVoiceToken> Authorize(string rcAccessToken)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("rcAccessToken", rcAccessToken);
            dict.Add("rcTokenType", "Bearer");
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{this.server}/api/auth/login/rc/accesstoken"),
                Content = new FormUrlEncodedContent(dict)
            };
            var r = await httpClient.SendAsync(httpRequestMessage);
            var engageVoiceToken =
                JsonConvert.DeserializeObject<EngageVoiceToken>(await r.Content.ReadAsStringAsync());
            this.token = engageVoiceToken;
            return engageVoiceToken;
        }
    }
}
