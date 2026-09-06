using Microsoft.Extensions.Options;
namespace ConsoleApiClient.Services;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(
        HttpClient httpClient,
        IOptions<ApiOptions> options)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
    }
    
    public async Task<string> GetAsync()
    {
        var response = await _httpClient.GetAsync("fact");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}