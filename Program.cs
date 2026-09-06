using ConsoleApiClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
{
    client.BaseAddress = new Uri(
        "https://catfact.ninja/");
});

using var host = builder.Build();

var apiClient = host.Services.GetRequiredService<IApiClient>();

var result = await apiClient.GetAsync();

Console.WriteLine(result);
