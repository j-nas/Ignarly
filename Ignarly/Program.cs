using Ignarly;

var githubClient = new GithubApi();
var templateList = await githubClient.GetGitIgnoreTemplates();

var selection = Interactive.SelectTemplate(templateList);

var gitignoreContent = await githubClient.GetGitIgnoreTemplate(selection);

var ignoreFile = new GitignoreFile(null);
if (ignoreFile.Content != string.Empty)
{
    switch (Interactive.FileExistsPrompt(ignoreFile.Path))
    {
        case FileExistsAction.Overwrite:
            ignoreFile.Content = gitignoreContent;
            ignoreFile.WriteToFile();
            break;
        case FileExistsAction.Append:
            ignoreFile.AppendToFile(gitignoreContent);
            break;
        case FileExistsAction.Cancel:
            Console.WriteLine("Operation cancelled");
            Environment.Exit(0);
            break;
    }
}
else
{
    ignoreFile.Content = gitignoreContent;
    ignoreFile.WriteToFile();
}

Environment.Exit(0);
