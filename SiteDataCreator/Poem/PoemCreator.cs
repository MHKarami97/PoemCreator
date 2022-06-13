namespace SiteDataCreator.Poem;

public static class PoemCreator
{
    public static async Task Create()
    {
        try
        {
            Console.WriteLine("Start");

            var poems = new List<string>();
            var counter = 1296;
            const string resultFolder = "resultPoem";
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            string? line;
            const string layout = "post";
            const string user = "سعدی";
            const string tags = "سعدی غزل";
            const string categories = "poem";
            var template = "---" +
                           "\n" +
                           $"layout: {layout}" +
                           "\n" +
                           $"title: {user}" +
                           "\n" +
                           $"tags: {tags}" +
                           "\n" +
                           $"categories: {categories}" +
                           "\n";

            const string template1 = "\n" +
                                     "---" +
                                     "\n" +
                                     "\n";

            using var sr = new StreamReader("Poem/poems.txt");

            while ((line = await sr.ReadLineAsync()) != null)
            {
                poems.Add(line);
            }

            var directoryInfo = Directory.CreateDirectory(resultFolder);

            foreach (var poem in poems)
            {
                try
                {
                    await using var sw = new StreamWriter($"{resultFolder}\\{today}-p{counter}.md");

                    await sw.WriteAsync(template +
                                        $"date: {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.ffffff")}" +
                                        template1 +
                                        poem);

                    counter++;
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
}