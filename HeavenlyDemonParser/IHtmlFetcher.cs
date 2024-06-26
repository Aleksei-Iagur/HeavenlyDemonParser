namespace HeavenlyDemonParser
{
    public interface IHtmlFetcher
    {
        Task<string> FetchHtmlAsync(string url);
    }

}
