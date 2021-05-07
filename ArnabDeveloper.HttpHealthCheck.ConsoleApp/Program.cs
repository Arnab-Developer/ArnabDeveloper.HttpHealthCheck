using ArnabDeveloper.HttpHealthCheck;
using ArnabDeveloper.HttpHealthCheck.ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

IHost host = CreateHostBuilder().Build();
var manager = ActivatorUtilities.CreateInstance<HealthCheckManager>(host.Services);
string logs = manager.LogHealthCheckResult();
Console.WriteLine(logs);

static IHostBuilder CreateHostBuilder()
{
    IHostBuilder hostBuilder =
        Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddHttpClient()
                    .AddTransient(typeof(IHealthCheck), typeof(HealthCheck))
                    .AddTransient(options =>
                    {
                        IEnumerable<IConfigurationSection> sections = context.Configuration.GetSection("ApiDetails").GetChildren();
                        List<ApiDetail> urlDetails = new();
                        for (var counter = 0; counter < sections.Count(); counter++)
                        {
                            urlDetails.Add(new ApiDetail
                            (
                                context.Configuration.GetValue<string>($"ApiDetails:{counter}:Name"),
                                context.Configuration.GetValue<string>($"ApiDetails:{counter}:Url"),
                                new ApiCredential
                                (
                                    context.Configuration.GetValue<string>($"ApiDetails:{counter}:Credential:UserName"),
                                    context.Configuration.GetValue<string>($"ApiDetails:{counter}:Credential:Password")
                                ),
                                context.Configuration.GetValue<bool>($"ApiDetails:{counter}:IsEnable")
                            ));
                        }
                        return urlDetails.AsEnumerable();
                    });
            });

    return hostBuilder;
}
