using ConsoleApiClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
{
    client.BaseAddress = new Uri(
        "https://catfact.ninja/");
});

builder.Services.AddSingleton<IFileLogger>(_ =>
    new FileLogger("logs/requests.txt"));

using var host = builder.Build();

var apiClient = host.Services.GetRequiredService<IApiClient>();
var fileLogger = host.Services.GetRequiredService<IFileLogger>();

var result = await apiClient.GetAsync();

Console.WriteLine(result);

await fileLogger.AppendAsync(result);