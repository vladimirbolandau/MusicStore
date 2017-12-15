using System.IO;

namespace MusicStore.Repository
{
    public class CacheRepository : ICacheRepository
    {
        public bool DoesFileExists(string path)
        {
            return File.Exists(path);
        }

        public void ClearCacheIn(string directory, string exceptFile)
        {
            foreach (var file in Directory.GetFiles(directory))
                if (file != exceptFile)
                    File.Delete(file);
        }

        public string GetCacheFile(string path)
        {
            string cacheFile = null;
            cacheFile = File.ReadAllText(path);
            return cacheFile;
        }

        public void CreateCacheFile(string path, string fileContents)
        {
            File.WriteAllText(path, fileContents);
        }
    }
}