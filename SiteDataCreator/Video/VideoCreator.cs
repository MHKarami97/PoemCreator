using System.Text;

namespace SiteDataCreator.Video;

public static class VideoCreator
{
    public static async Task Create()
    {
        try
        {
            Console.WriteLine("Start");

            /*
             *  get all file names:   dir /b > filenames.txt
             */
            const string resultFolder = "resultVideo";
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var items = new List<string>();
            string? line;

            const string layout = "post";
            const string tags = "none";
            const string categories = "none";

            const string template = "---" +
                                    "\n" +
                                    $"layout: {layout}" +
                                    "\n" +
                                    "title:";

            var template1 = "\n" +
                            $"dates: {today}" +
                            "\n" +
                            "description:";

            const string template2 = "\n" +
                                     "img: ";

            const string template3 = "\n" +
                                     $"tags: [{tags}]" +
                                     "\n" +
                                     $"categories: [{categories}]" +
                                     "\n" +
                                     "---" +
                                     "\n" +
                                     "\n";

            const string template4 = "[imdb]()  " +
                                     "\n" +
                                     "[RottenTomatoes]()";

            using var sr = new StreamReader("Video/videos.txt");

            while ((line = await sr.ReadLineAsync()) != null)
            {
                items.Add(line);
            }

            var directoryInfo = Directory.CreateDirectory(resultFolder);

            foreach (var item in items)
            {
                try
                {
                    await using var sw = new StreamWriter($"{resultFolder}\\{today}-{item}.md");

                    var title = GetTitle(item);

                    var resultText = $"{template}{title}{template1}{title}{template2}{item}.jpg{template3}{template4}";

                    await sw.WriteLineAsync(resultText);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.WriteLine("finish");
            Console.WriteLine(directoryInfo.FullName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static string GetTitle(string input)
    {
        var result = new StringBuilder();
        var tmp = input.Split('_');

        foreach (var item in tmp)
        {
            result.Append(" " + char.ToUpper(item[0]) + item[1..]);
        }

        return result.ToString();
    }
}