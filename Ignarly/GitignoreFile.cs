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

    public void SetContent(string content)
    {
        if (Content != string.Empty)
        {
            switch (Interactive.FileExistsPrompt(Path))
            {
                case FileExistsAction.Overwrite:
                    Content = content;
                    WriteToFile();
                    break;
                case FileExistsAction.Append:
                    Content += content;
                    WriteToFile();
                    break;
                case FileExistsAction.Cancel:
                    CancelOperation();
                    break;
            }
        }
        else
        {
            Content = content;
            WriteToFile();
        }
    }

    public void WriteToFile()
    {
        using (var fileWriter = new StreamWriter(Path))
        {
            fileWriter.Write(Content);
        }

        Console.WriteLine($"Gitignore rules written to {Path}");
    }

    public static void CancelOperation()
    {
        Console.WriteLine("Operation cancelled, no changes made to .gitignore file");
        Environment.Exit(420);
    }
}
