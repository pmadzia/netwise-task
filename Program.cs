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

builder.Services.AddTransient<IRequestService, RequestService>();

using var host = builder.Build();

var request = host.Services.GetRequiredService<IRequestService>();

await request.ProcessAsync();