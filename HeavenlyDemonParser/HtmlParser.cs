using HeavenlyDemonParser;
using HtmlAgilityPack;
using System.Text;

public class HtmlParser : IHtmlParser
{
    public Chapter ParseHtml(string html)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        var chapterTitle = htmlDoc.DocumentNode.SelectSingleNode("//h2[contains(@class, 'chapter-title')]").InnerText;
        var chapterId = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='cur_chp']").GetAttributeValue("chp_id", "-1");
        var prevLink = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='prev_chp_url']/text()").InnerText;
        var nextLink = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='next_chp_url']/text()").InnerText;
        var chapterTextNodes = htmlDoc.DocumentNode.SelectNodes("//p");

        StringBuilder sb = new();

        if (chapterTextNodes != null)
        {
            foreach (var node in chapterTextNodes.Skip(3).SkipLast(1))
            {
                sb.AppendLine(node.InnerText.Trim());
            }
        }

        return new Chapter
        {
            Id = chapterId,
            Title = chapterTitle,
            PreviousLink = prevLink,
            NextLink = nextLink,
            Text = sb.ToString()
        };
    }
}
