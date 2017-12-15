using System.Xml;

namespace MusicStore.Repository
{
    public class XmlRepository : IXmlRepository
    {
        public string LoadDataFromApi()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.rss");
            var appleProvider = new AlbumArtForXml();
            appleProvider.AddAlbumArtToXmlDoc(xmlDoc);
            return xmlDoc.OuterXml;
        }
    }
}
