using System.Text;

namespace SiteDataCreator.Video;

public static class VideoCreator
{
    public static void Create()
    {
        try
        {
            Console.WriteLine("Start");

            using var sr = new StreamReader("Video/videos.txt");
            const string resultFolder = "resultVideo";
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var items = new List<string>();
            string? line;

            const string layout = "post";
            const string tags = "none";
            const string categories = "none";

            var template = "---" +
                           "\n" +
                           $"layout: {layout}" +
                           "\n" +
                           "title:";

            var template1 = "\n" +
                            $"dates: {today}" +
                            "\n" +
                            "description:";

            var template2 = "\n" +
                            "img: ";

            var template3 = "\n" +
                            $"tags: [{tags}]" +
                            "\n" +
                            $"categories: [{categories}]" +
                            "\n" +
                            "---" +
                            "\n" +
                            "\n";

            var template4 =
                "[imdb]()  " +
                "\n" +
                "[RottenTomatoes]()";

            while ((line = sr.ReadLine()) != null)
            {
                items.Add(line);
            }

            Directory.CreateDirectory(resultFolder);

            foreach (var item in items)
            {
                try
                {
                    using var sw = new StreamWriter($"{resultFolder}\\{today}-{item}.md");

                    var title = GetTitle(item);

                    var resultText = $"{template}{title}{template1}{title}{template2}{item}.jpg{template3}{template4}";

                    sw.WriteLine(resultText);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.WriteLine("finish");
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