using MusicStore.Entities;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace MusicStore.Business.Infrastructure
{
    public class CacheFile
    {
        public string GetCacheFile(string path)
        {
            string cacheFile = null;
            cacheFile = File.ReadAllText(path);
            return cacheFile;
        }

        public void CreateCacheFile(string path, DataTransferType dataTransferType)
        {
            if (dataTransferType == DataTransferType.Xml)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.rss");
                var appleProvider = new AlbumArtForXml();
                appleProvider.AddAlbumArtToXmlDoc(xmlDoc);
                xmlDoc.Save(path);
            }
            else
            {
                string json = null;
                var jsonWeb = new WebClient()
                    .DownloadString("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
                byte[] data = Encoding.Default.GetBytes(jsonWeb);
                json = Encoding.UTF8.GetString(data);
                File.WriteAllText(path, json);
            }
        }
    }
}
