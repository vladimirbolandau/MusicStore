using System.IO;
using System.Xml;
using System.Net;
using MusicStore.Entities;
using MusicStore.Repository.Infrastructure;

namespace MusicStore.Repository
{
    public class CacheRepository
    {
        public void CheckFileExistence(string directory, string path, DataTransferType fileType)
        {
            if (!File.Exists(path))
            {
                CreateCacheByFile(fileType, path);
            }
            ClearCacheIn(directory, path);
        }

        public void ClearCacheIn(string directory, string exceptFile)
        {
            foreach (var file in Directory.GetFiles(directory))
                if (file != exceptFile)
                    File.Delete(file);
        }

        public void CreateCacheByFile(DataTransferType type, string path)
        {
            switch (type)
            {
                case DataTransferType.Xml:
                    var tempDoc = new XmlDocument();
                    tempDoc.Load(
                        "https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.rss");
                    var appleProvider = new AlbumArtForXml();
                    appleProvider.AddAlbumArtToXmlDoc(tempDoc);
                    tempDoc.Save(path);
                    break;
                case DataTransferType.Json:
                    var json = new WebClient().DownloadString(
                        "https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
                    File.WriteAllText(path, json);
                    break;
                default:
                    break;
            }
        }
    }
}