using MongoDB.Driver;

namespace HeavenlyDemonParser
{


    public class ChapterRepository : IChapterRepository
    {
        private readonly IMongoCollection<Chapter> _chapters;

        public ChapterRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _chapters = database.GetCollection<Chapter>("chapters");
        }

        public async Task SaveChapterAsync(Chapter chapter)
        {
            await _chapters.InsertOneAsync(chapter);
        }
    }

}
