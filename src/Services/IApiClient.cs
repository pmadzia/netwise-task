namespace ConsoleApiClient.Services;
public interface IApiClient
{
    Task<string> GetAsync();
}