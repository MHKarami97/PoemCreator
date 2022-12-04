namespace SiteDataCreator.Link;

public static class LinkCreator
{
    public static async Task Create()
    {
        try
        {
            Console.WriteLine("Start");

            var links = new List<string>();
            var counter = 02;
            const string resultFolder = "resultLink";
            var today = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string? line;
            const string layout = "post";
            const string tags = "";
            const string categories = "link";
            const string template = "---" +
                                    "\n" +
                                    $"layout: {layout}" +
                                    "\n";
            
            const string template1 = "\n" +
                                     $"categories: {categories}"+
                                     "\n" +
                                     $"tags: [{tags}]" +
                                     "\n" +
                                     "---";

            using var sr = new StreamReader("Link/links.txt");

            while ((line = await sr.ReadLineAsync()) != null)
            {
                links.Add(line);
            }

            var directoryInfo = Directory.CreateDirectory(resultFolder);

            foreach (var link in links)
            {
                try
                {
                    await using var sw = new StreamWriter($"{resultFolder}\\{today}-link{counter.ToString("00")}.md");

                    await sw.WriteAsync(template +
                                        $"title: {link}" +
                                        template1);

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