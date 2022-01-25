using PoemCreator;

Console.WriteLine("Start");

try
{
    const bool needFormat = false;

    if (needFormat)
    {
        /*
         
        Mo(.*?)\]
        دیوان اشعار, غزلیات - سعدی
        -
        ^$\n
        \n => / 
        - => \n
        ^ / 
         / $
 
         */
        var txt = @"";

        var formatter = new Formatter();

        var resultD = formatter.Format(txt);
    }

    using var sr = new StreamReader("poems.txt");
    var poems = new List<string>();
    var counter = 829;
    const string resultFolder = "result";
    var today = DateTime.Now.ToString("yyyy-M-d");
    string? line;
    const string layout = "post";
    const string user = "سعدی";
    const string tags = "سعدی غزل";
    const string categories = "poem";
    const string template = "---" +
                            "\n" +
                            $"layout: {layout}" +
                            "\n" +
                            $"title: {user}" +
                            "\n" +
                            $"tags: {tags}" +
                            "\n" +
                            $"categories: {categories}" +
                            "\n" +
                            "---" +
                            "\n" +
                            "\n";

    while ((line = sr.ReadLine()) != null)
    {
        poems.Add(line);
    }

    Directory.CreateDirectory(resultFolder);

    foreach (var poem in poems)
    {
        try
        {
            using var sw = new StreamWriter($"{resultFolder}\\{today}-p{counter}.md");
            sw.WriteLine(template + poem);

            counter++;
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