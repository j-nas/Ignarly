using Octokit;

namespace Ignarly;

public class GithubApi
{
    readonly GitHubClient _client;

    public GithubApi()
    {
        _client = new GitHubClient(new ProductHeaderValue("Ignarly"));
    }

    public async Task<IReadOnlyList<string>> GetGitIgnoreTemplates()
    {
        try
        {
            return await _client.GitIgnore.GetAllGitIgnoreTemplates();
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to fetch gitignore templates from GitHub");
            throw;
        }
    }

    public async Task<string> GetGitIgnoreTemplate(string selection)
    {
        try
        {
            return (await _client.GitIgnore.GetGitIgnoreTemplate(selection)).Source;
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to fetch gitignore template from GitHub");
            throw;
        }
    }
}
