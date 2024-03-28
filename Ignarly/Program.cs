using Octokit;
using Spectre.Console;


var github = new GitHubClient(new ProductHeaderValue("Ignarly"));
var contents = await github.Repository.Content.GetAllContents("github", "gitignore", "/");

var gitignoreFiles = contents.Where(c => c.Name.EndsWith(".gitignore")).ToList();
var fileListNoExtension = gitignoreFiles.Select(f => f.Name.Replace(".gitignore", "")).ToList();

var selection = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Select a .gitignore template")
        .EnableSearch()
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
        .AddChoices(fileListNoExtension)
);
Console.WriteLine($"You selected: {selection}");

var gitignoreFile = contents.First(c => c.Name == $"{selection}.gitignore");
var httpClient = new HttpClient();
var gitignoreContent = await httpClient.GetStringAsync(gitignoreFile.DownloadUrl);
Console.WriteLine(gitignoreContent);
var fileWriter = new StreamWriter("test.gitignore");
fileWriter.Write(gitignoreContent);
Console.ReadKey();