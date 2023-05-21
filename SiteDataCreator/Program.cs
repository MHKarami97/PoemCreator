using SiteDataCreator.Image;
using SiteDataCreator.Link;
using SiteDataCreator.Music;
using SiteDataCreator.Poem;
using SiteDataCreator.Travel;
using SiteDataCreator.Video;

try
{
    Console.WriteLine("enter item:");
    Console.WriteLine("v : Video");
    Console.WriteLine("i : Image");
    Console.WriteLine("t : Travel");
    Console.WriteLine("p : Poem");
    Console.WriteLine("l : Link");
    Console.WriteLine("m : Music");

    var witch = Console.ReadLine()?.ToLower();

    switch (witch)
    {
        case "v":
            await VideoCreator.Create();
            break;

        case "t":
            await TravelCreator.Create();
            break;

        case "i":
            await ImageCreator.Create();
            break;

        case "p":
            await PoemCreator.Create();
            break;
        
        case "l":
            await LinkCreator.Create();
            break;
        
        case "m":
            await MusicCreator.Create();
            break;

        default:
            Console.WriteLine("not valid input");
            break;
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}