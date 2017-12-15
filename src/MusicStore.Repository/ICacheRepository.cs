namespace MusicStore.Repository
{
    public interface ICacheRepository
    {
        bool DoesFileExists(string path);

        void ClearCacheIn(string directory, string exceptFile);

        string GetCacheFile(string path);

        void CreateCacheFile(string path, string fileContents);
    }
}
