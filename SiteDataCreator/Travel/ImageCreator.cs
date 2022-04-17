namespace SiteDataCreator.Travel;

public static class ImageCreator
{
    public static void Create()
    {
        try
        {
            Console.WriteLine("Start");

            const int counter = 255;
            const string line = "---";
            const string resultFolder = "resultTravel";
            var today = DateTime.Now.ToString("yyyy-MM-dd");

            Directory.CreateDirectory(resultFolder);

            for (var i = 1; i < counter; i++)
            {
                try
                {
                    using var sw = new StreamWriter($"{resultFolder}\\{today}-picture{i}.md");

                    var input = $"{line}\ntitle:  \"picture{i}\"\nimage:  \"/assets/img/{i.ToString("000")}.jpg\"\n{line}";

                    sw.WriteLine(input);
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
}