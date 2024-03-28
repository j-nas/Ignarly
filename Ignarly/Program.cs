using Ignarly;

var githubClient = new GithubApi();
var templateList = await githubClient.GetGitIgnoreTemplates();

var selection = Interactive.SelectTemplate(templateList);

var gitignoreContent = await githubClient.GetGitIgnoreTemplate(selection);

var ignoreFile = new GitignoreFile(null);
ignoreFile.SetContent(gitignoreContent);

Environment.Exit(0);
