namespace MusicStore.Repository
{
    public interface ICacheRepository
    {
        bool DoesFileForTodayExists(string path);

        void ClearCacheIn(string directory, string exceptFile);
    }
}
