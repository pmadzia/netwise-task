using System.Text.Json;

namespace ConsoleApiClient.Services;

public class RequestService(IApiClient apiClient, IFileLogger fileLogger) : IRequestService
{
    private readonly IApiClient _apiClient = apiClient;
    private readonly IFileLogger _fileLogger = fileLogger;

    public async Task ProcessAsync()
    {
        var result = await _apiClient.GetAsync();

        var json = JsonSerializer.Deserialize<JsonElement>(result);

        var message = $"Fact: {json.GetProperty("fact").GetString()} | Length: {json.GetProperty("length").GetInt32()}";


        await _fileLogger.AppendAsync(result);

        Console.WriteLine(message);
    }
}