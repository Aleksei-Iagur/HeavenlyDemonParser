namespace HeavenlyDemonParser
{
    public class HtmlFetcher : IHtmlFetcher
    {
        private readonly HttpClient _httpClient;

        public HtmlFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> FetchHtmlAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

}
