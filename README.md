# HTTP health check

This is a library to check health of HTTP endpoint. It has been hosted in 
[NuGet](https://www.nuget.org/packages/ArnabDeveloper.HttpHealthCheck/). 
Use below command to install this in your .NET application.

```
dotnet add package ArnabDeveloper.HttpHealthCheck
```

Use any HTTP endpoint to check their health.

```csharp
IHttpClientFactory httpClientFactory; // Use ASP.NET DI to build this
IHealthCheck healthCheck = new HealthCheck(httpClientFactory);
string urlToCheck = "<your http url>";
bool isApiHealthy = await _healthCheck.IsHealthyAsync(urlToCheck);
if (isApiHealthy)
{
    // URL is healthy
}
else
{
    // URL is unhealthy
}
```

There is a 
[dashboard app](https://github.com/Arnab-Developer/HttpHealthCheckDashboard) 
which uses the library to check health of some http endpoints. This is to show 
how you can use this library in your app.