using SiteDataCreator.Poem;
using SiteDataCreator.Travel;
using SiteDataCreator.Video;

try
{
    VideoCreator.Create();
    //ImageCreator.Create();
    //PoemCreator.Create();
}
catch (Exception e)
{
    Console.WriteLine(e);
}