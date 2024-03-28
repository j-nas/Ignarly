using Ignarly;
using Octokit;

var client = new GitHubClient(new ProductHeaderValue("Ignarly"));
var templateList = await client.GitIgnore.GetAllGitIgnoreTemplates();

var selection = Interactive.SelectTemplate(templateList);
Console.WriteLine($"You have selected: {selection}");

var gitignoreContent = await client.GitIgnore.GetGitIgnoreTemplate(selection);

var fileWriter = new StreamWriter("test.gitignore");
fileWriter.Write(gitignoreContent.Source);
