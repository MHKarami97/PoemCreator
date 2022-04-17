using System.Text.RegularExpressions;

namespace SiteDataCreator.Poem;

public class Formatter
{
    private const string HeaderRegex = "Mo(.*?)\\]";
    private const string NewLineRegex = "^$\n";
    private const string Separator = "-";
    private const string PoemSeparator = " / ";
    private const string NewLine = "\n";
    private const string StartString = "^ / ";
    private const string EndString = " / $";
    private const string PoemText = "دیوان اشعار, غزلیات - سعدی";

    public List<string> Format(string input)
    {
        var data = ReplaceByRegex(input, HeaderRegex);
        data = ReplaceByText(data, PoemText, Separator);
        data = ReplaceByRegex(data, NewLineRegex);
        data = ReplaceByRegex(data, NewLine, PoemSeparator);
        data = ReplaceByRegex(data, StartString);
        data = ReplaceByRegex(data, EndString);

        var result = data.Split("\n").ToList();

        return result;
    }

    private string ReplaceByRegex(string input, string regex, string? replace = null)
    {
        var separator = replace ?? "";

        var result = Regex.Replace(input, regex, separator);

        return result;
    }

    private string ReplaceByText(string input, string text, string? replace = null)
    {
        var separator = replace ?? "";

        var result = input.Replace(text, separator);

        return result;
    }
}