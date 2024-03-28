using Spectre.Console;

namespace Ignarly;

public static class Interactive
{
    static public string SelectTemplate(IEnumerable<string> templateList)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(templateList)
                .Title("Select a .gitignore template")
                .EnableSearch()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
        );
    }
}
