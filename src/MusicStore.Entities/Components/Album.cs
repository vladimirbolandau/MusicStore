using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MusicStore.Entities
{
    public class Album
    {
        public string Name { get; set; }
        public Artist ArtistName { get; set; }
        public Genre GenreName { get; set; }
        public DateTime DateRelease { get; set; }
        public string AlbumLink { get; set; }
        public string AlbumArtUrl { get; set; }
        public Album()
        {
            Name = "No Album";
            ArtistName = new Artist();
            GenreName = new Genre();
            DateRelease = new DateTime();
            AlbumLink = "No Link";
            AlbumArtUrl = "No URL";
        }
        public Album(string name, string artistName, string genreName, string dateRelease, string albumLink)
        {
            Name = name;
            ArtistName = new Artist(artistName);
            GenreName = new Genre(genreName);
            try
            {
                DateRelease = DateTime.ParseExact(dateRelease, "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
                System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                DateRelease = new DateTime();
            }
            
            AlbumLink = albumLink;
            AlbumArtUrl = GetAlbumArtUrlFromLink(albumLink);
        }
        private string GetAlbumArtUrlFromLink(string link)
        {
            WebClient client = new WebClient();
            string resource = client.DownloadString(link);
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(resource);
            var imgDiv = html.DocumentNode.SelectSingleNode(
                "//*[contains(@class,'product-artwork we-artwork--fullwidth we-artwork ember-view')]");
            var imgSrc = imgDiv.SelectSingleNode("//img/@src");
            string relativePath = imgSrc.GetAttributeValue("src", "");
            return relativePath;
        }
    }
}