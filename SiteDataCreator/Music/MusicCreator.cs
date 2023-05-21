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

                await sw.WriteAsync($"title:{song}" +
                                    "\n" +
                                    "layout: post" +
                                    "\n" +
                                    $"categories: [{name}]" +
                                    "\n" +
                                    "type: main" +
                                    "\n" +
                                    $"file: /assets/music/{item}.mp3" +
                                    "\n" +
                                    "---");
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