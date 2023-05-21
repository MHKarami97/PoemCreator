using System.Globalization;

namespace SiteDataCreator.Music;

public static class MusicCreator
{
    public static async Task Create()
    {
        Console.WriteLine("Start");

        var d = new DirectoryInfo(@"D:\Local\my\music\assets\music");
        var files = d.GetFiles("*.mp3");
        var items = files.Select(file => file.Name).ToList();
        items = items.Select(file => file.Replace(".mp3", "")).ToList();

        const string resultFolder = "resultMusic";
        var today = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        const string layout = "post";
        const string type = "main";
        const string template = "---" +
                                "\n" +
                                $"layout: {layout}" +
                                "\n" +
                                $"layout: {type}" +
                                "\n";

        const string template1 = "\n" +
                                 "---";

        var directoryInfo = Directory.CreateDirectory(resultFolder);

        foreach (var item in items)
        {
            try
            {
                var splitData = item.Split('-');

                var name = splitData[0];

                var song = "";

                for (var i = 1; i < splitData.Length; i++)
                {
                    song += " " + splitData[i];
                }

                var textInfo = new CultureInfo("en-US", false).TextInfo;
                song = textInfo.ToTitleCase(song);

                await using var sw = new StreamWriter($"{resultFolder}\\{today}-{item}.md");

                await sw.WriteAsync(template +
                                    $"title: {song}" +
                                    "\n" +
                                    $"categories: [{name}]" +
                                    "\n" +
                                    $"file: /assets/music/{name}.mp3" +
                                    template1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        Console.WriteLine("finish");
        Console.WriteLine(directoryInfo.FullName);
    }
}