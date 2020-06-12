using System;
using Xunit;
using RingCentral;
using dotenv.net;

namespace EngageVoice.Tests
{
    public class HttpMethodsTest
    {
        [Fact]
        public async void TestGet()
        {
            DotEnv.Config(true);
            var rc = new RestClient(
                Environment.GetEnvironmentVariable("RINGCENTRAL_CLIENT_ID"),
                Environment.GetEnvironmentVariable("RINGCENTRAL_CLIENT_SECRET"),
                Environment.GetEnvironmentVariable("RINGCENTRAL_SERVER_URL")
            );
            await rc.Authorize(
                Environment.GetEnvironmentVariable("RINGCENTRAL_USERNAME"),
                Environment.GetEnvironmentVariable("RINGCENTRAL_EXTENSION"),
                Environment.GetEnvironmentVariable("RINGCENTRAL_PASSWORD")
            );
            
            var engageVoice = new EngageVoice(Environment.GetEnvironmentVariable("ENGAGE_VOICE_SERVER_URL"));
            var engageVoiceToken = await engageVoice.Authorize(rc.token.access_token);
            Assert.NotNull(engageVoiceToken);
            Assert.NotNull(engageVoiceToken.accessToken);

            var httpResponseMessage = await engageVoice.Get("/voice/api/v1/admin/accounts");
            var s = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.NotNull(s);
            Assert.NotEmpty(s);

            await rc.Revoke();
        }
    }
}