using Microsoft.Extensions.Options;

namespace ConsoleApiClient.Services;

public class FileLogger(IOptions<FileOptions> options) : IFileLogger
{
    private readonly string _filePath = options.Value.Path;

    public async Task AppendAsync(string message)
    {
        var directory = Path.GetDirectoryName(_filePath);

        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var line = $"{DateTime.Now:dd-MM-yyyy HH::mm:ss} || {message}{Environment.NewLine}";

        await File.AppendAllTextAsync(_filePath, line);
    }
}