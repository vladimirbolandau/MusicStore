using System;
using System.Net;
using System.Xml;

namespace MusicStore.Repository
{
    public class AlbumArtForXml
    {
        public void AddAlbumArtToXmlDoc(XmlDocument xmlDoc)
        {
            foreach (XmlNode xnode in xmlDoc.SelectNodes("//item"))
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "guid")
                    {
                        childnode.InnerText = GetAlbumArtUrl(childnode.InnerText);
                    }
                }
            }
        }

        public string GetAlbumArtUrl(string linkToAlbum)
        {
            WebClient client = new WebClient();
            string resource = client.DownloadString(linkToAlbum);
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(resource);
            HtmlAgilityPack.HtmlNode imgDiv = null;
            try
            {
                imgDiv = html.DocumentNode.SelectSingleNode(
                    "//*[contains(@class,'product-artwork we-artwork--fullwidth we-artwork ember-view')]");
            }
            catch (Exception)
            {
                imgDiv = html.DocumentNode.SelectSingleNode("//*[contains(@class,'artwork')]");
            }
            var imgSrc = imgDiv.SelectNodes("//img/@src");// .SelectSingleNode("//img/@src");
            string AlbumArtUrl = imgSrc[1].GetAttributeValue("src", "");
            return AlbumArtUrl;
        }
    }
}
