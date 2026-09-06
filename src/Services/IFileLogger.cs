namespace ConsoleApiClient.Services;

public interface IFileLogger
{
    Task AppendAsync(string message);
}