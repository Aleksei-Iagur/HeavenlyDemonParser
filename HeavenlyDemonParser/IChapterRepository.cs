namespace HeavenlyDemonParser
{
    public interface IChapterRepository
    {
        Task SaveChapterAsync(Chapter chapter);
    }
}
