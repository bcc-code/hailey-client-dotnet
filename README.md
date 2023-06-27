# Hailey Client for .Net

A .Net Client/SDK based on the Hailey swagger specification: https://api.haileyhr.app/docs/v1/docs.json

## Project Structure

* **BccCode.Hailey.Client** - SDK
    - HaileyClientGenerated.cs -- client generated using NSwag.net
	- HaileyClient.cs -- custom extentions to generated client, to better facilitate authentication, token caching etc.

* **BccCode.Hailey.Tests** - SDK tests


## Updating client 
In order to re-generate the client code (based on a new swagger specification):
1. open the project in Visual Studio 2022
2. Select "Generate" as the build configuration (instead of Release or Debug)
3. Build the project

The project file includes a number of "PreBuildEvents" which are run when the project is built in with "Generate" configuration selected.   
These prebuild tasks perform the following operations:
* Generate code using Nswag.net using the configuration in `nswag.json`

## .Net SDK

To use the SDK in a .Net application, add the `BccCode.Hailey.Client` nuget package.

The `IHaileyClient` service can be added to the applications services during startup (startup.cs or program.cs) using the following code (.net 6):

```csharp
\\ ...

builder.Services.AddHaileyClient(new HaileyClientOptions
{
    ApiKey = "<your api key>"
});

```