namespace SiteDataCreator.Travel;

public static class TravelCreator
{
    public static async Task Create()
    {
        try
        {
            Console.WriteLine("Start");

            const int counter = 406;
            const string line = "---";
            const string resultFolder = "resultTravel";
            var today = DateTime.Now.ToString("yyyy-MM-dd");

            var directoryInfo = Directory.CreateDirectory(resultFolder);

            for (var i = 1; i < counter; i++)
            {
                try
                {
                    await using var sw = new StreamWriter($"{resultFolder}\\{today}-picture{i}.md");

                    var input =
                        $"{line}\ntitle:  \"picture{i}\"\nimage:  \"/assets/img/{i.ToString("000")}.jpg\"\n{line}";

                    await sw.WriteLineAsync(input);
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