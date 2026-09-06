using System.ComponentModel.DataAnnotations;

namespace ConsoleApiClient.Services;

public class FileOptions
{
    [Required]
    public string Path { get; set; } = string.Empty;
}