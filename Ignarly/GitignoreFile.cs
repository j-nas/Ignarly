namespace Ignarly;

public class GitignoreFile
{
    public string Path { get; set; }
    public string Content { get; set; }

    public GitignoreFile(string? path)
    {
        Path = Directory.GetCurrentDirectory() + "/.gitignore";
        if (path is not null)
        {
            Path = path + "/.gitignore";
        }

        if (File.Exists(Path))
        {
            Content = File.ReadAllText(Path);
        }
        else
        {
            Content = string.Empty;
        }
    }

    public void WriteToFile()
    {
        using (var fileWriter = new StreamWriter(Path))
        {
            fileWriter.Write(Content);
        }

        Console.WriteLine($"File written to {Path}");
    }

    public void AppendToFile(string content)
    {
        Content += content;
        WriteToFile();
    }
}
