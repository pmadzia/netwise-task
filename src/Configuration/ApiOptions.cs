using System.ComponentModel.DataAnnotations;

namespace ConsoleApiClient.Services;

public class ApiOptions
{
    [Required]
    public string BaseUrl { get; set; } = string.Empty;
}