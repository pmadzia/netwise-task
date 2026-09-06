namespace ConsoleApiClient.Services;

public class RequestService(IApiClient apiClient, IFileLogger fileLogger) : IRequestService
{
    private readonly IApiClient _apiClient = apiClient;
    private readonly IFileLogger _fileLogger = fileLogger;

    public async Task ProcessAsync()
    {
        var result = await _apiClient.GetAsync();

        await _fileLogger.AppendAsync(result);

        Console.WriteLine(result);
    }
}