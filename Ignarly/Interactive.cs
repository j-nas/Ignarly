using System.Security.Cryptography;
using Spectre.Console;

namespace Ignarly;

public static partial class Interactive
{
    public static string SelectTemplate(IEnumerable<string> templateList)
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(templateList)
                .Title("Select a .gitignore template")
                .EnableSearch()
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
        );
        Console.WriteLine($"You have selected: {selection}");
        return selection;
    }

    public static FileExistsAction FileExistsPrompt(string path)
    {
        AnsiConsole.MarkupLine($"[red]File {path} already exists[/]");
        AnsiConsole.MarkupLine(
            "[yellow]Do you want to (o)overwrite, (a)append or (c or any key)cancel?[/]"
        );
        var actions = Console.ReadKey(true);

        return actions.Key switch
        {
            ConsoleKey.O => FileExistsAction.Overwrite,
            ConsoleKey.A => FileExistsAction.Append,
            ConsoleKey.C => FileExistsAction.Cancel,
            _ => FileExistsAction.Cancel
        };
    }
}
