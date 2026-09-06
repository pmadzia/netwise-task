using ConsoleApiClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddOptions<ApiOptions>()
    .Bind(builder.Configuration.GetSection("Api"))
    .ValidateDataAnnotations()
    .ValidateOnStart();;

builder.Services
    .AddOptions<ConsoleApiClient.Services.FileOptions>()
    .Bind(builder.Configuration.GetSection("File"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddHttpClient<IApiClient, ApiClient>();

builder.Services.AddSingleton<IFileLogger, FileLogger>();

builder.Services.AddTransient<IRequestService, RequestService>();

using var host = builder.Build();

var request = host.Services.GetRequiredService<IRequestService>();

while (true)
{
    Console.Write("Do you want to make a request? (y/n): ");

    var answer = Console.ReadLine();

    if (answer?.ToLower() == "y")
    {
        await request.ProcessAsync();
    }
    else if (answer?.ToLower() == "n")
    {
        break;
    }
}