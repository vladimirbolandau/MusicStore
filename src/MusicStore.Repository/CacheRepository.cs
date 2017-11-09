using System.IO;

namespace MusicStore.Repository
{
    public class CacheRepository
    {
        public bool DoesFileForTodayExists(string directory, string path)
        {
            bool existence = true;
            if (!File.Exists(path))
            {
                existence = false;
            }
            return existence;
        }

        public void ClearCacheIn(string directory, string exceptFile)
        {
            foreach (var file in Directory.GetFiles(directory))
                if (file != exceptFile)
                    File.Delete(file);
        }
    }
}