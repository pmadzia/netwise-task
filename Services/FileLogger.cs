namespace ConsoleApiClient.Services;

public class FileLogger(string filePath) : IFileLogger
{
    private readonly string _filePath = filePath;

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