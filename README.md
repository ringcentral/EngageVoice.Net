# EngageVoice.Net

RingCentral Engage Voice SDK for .NET


## Installation

This SDK assumes that you have a RingCentral token. 
You can use [RingCentral.Net SDK](https://github.com/ringcentral/RingCentral.Net) to get a RingCentral token.
Please install it first, here is [its installation instructions](https://github.com/ringcentral/RingCentral.Net#installation).

This SDKPackage is available on NuGet: [https://www.nuget.org/packages/EngageVoice.Net](https://www.nuget.org/packages/EngageVoice.Net).
You can install it just like you install any other NuGet packages.


## Usage

```cs
var rc = new RestClient(clientId, clientSecret, rcServer);
await rc.Authorize(username, extension, password);

var engageVoice = new EngageVoice();
await engageVoice.Authorize(rc.token.access_token);

var httpResponseMessage = await engageVoice.Get("/voice/api/v1/admin/accounts");
```


## Todo

- Add models:
    - Swagger spec: https://github.com/ringcentral/engage-voice-api-docs/blob/master/specs/engage-voice_openapi3.json
