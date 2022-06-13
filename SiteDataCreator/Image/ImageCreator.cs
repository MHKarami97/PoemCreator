namespace SiteDataCreator.Image;

public static class ImageCreator
{
    public static async Task Create()
    {
        try
        {
            const int last = 283;
            const string resultFolder = "resultImage";

            const string template = "<p align=\"center\"><img src=\"/assets/img/47-kurdistan/";
            const string template2 = ".jpg\" alt=\"mhkarami97\" /></p>\n";

            const string template3 = "![mhkarami97](/assets/img/55-neor_lake_to_subatan/";
            const string template4 = ".jpg)  \n";

            var directoryInfo = Directory.CreateDirectory(resultFolder);

            await using var sw = new StreamWriter($"{resultFolder}/{resultFolder}.md");

            for (var i = 1; i < last; i++)
            {
                try
                {
                    await sw.WriteLineAsync(template3 + i.ToString("000") + template4 + "  \n");
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