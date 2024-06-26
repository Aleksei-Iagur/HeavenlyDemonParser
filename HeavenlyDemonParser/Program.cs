using HeavenlyDemonParser;

var httpClient = new HttpClient();
IHtmlFetcher htmlFetcher = new HtmlFetcher(httpClient);
IHtmlParser htmlParser = new HtmlParser();
var mongoUrl = Environment.GetEnvironmentVariable("heavenly-demon-mongodb");
IChapterRepository chapterRepository = new ChapterRepository(mongoUrl!, "HeavenlyDemon");

var url = "https://www.novelcool.com/chapter/The-Heavenly-Demon-Can-t-Live-a-Normal-Life-Chapter-365/8107214/";

while (!string.IsNullOrEmpty(url))
{
    var html = await htmlFetcher.FetchHtmlAsync(url);
    var chapter = htmlParser.ParseHtml(html);
    chapter.Url = url;
    await chapterRepository.SaveChapterAsync(chapter);

    Console.WriteLine($"Next Page Link: {chapter.NextLink}");

    url = chapter.NextLink;

    if (string.IsNullOrEmpty(url))
    {
        Console.WriteLine("No next page found. Stopping...");
        break;
    }
    await Task.Delay(300);
}