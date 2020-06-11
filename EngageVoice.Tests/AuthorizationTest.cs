using System;
using Xunit;
using RingCentral;
using dotenv.net;

namespace EngageVoice.Tests
{
    public class AuthorizationTest
    {
        [Fact]
        public async void TestAuthorize()
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
            
            var engageVoice = new EngageVoice();
            var engageVoiceToken = await engageVoice.Authorize(rc.token.access_token);
            Assert.NotNull(engageVoiceToken);
            Assert.NotNull(engageVoiceToken.accessToken);

            await rc.Revoke();
        }
    }
}