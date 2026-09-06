namespace ConsoleApiClient.Services;

public class ApiClient(HttpClient httpClient) : IApiClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GetAsync()
    {
        var response = await _httpClient.GetAsync("fact");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}