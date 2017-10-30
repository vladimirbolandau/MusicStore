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
        public Album(string name, string artistName, string genreName,
            string dateRelease, string albumLink, string artLink)
        {
            Name = name;
            ArtistName = new Artist(artistName);
            GenreName = new Genre(genreName);
            try
            {
                DateRelease = DateTime.ParseExact(dateRelease, "ddd, dd MMM yyyy HH':'mm':'ss zzz",
                System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                try
                {
                    DateRelease = DateTime.ParseExact(dateRelease, "yyyy-MM-dd",
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    DateRelease = new DateTime();
                }
            }
            
            AlbumLink = albumLink;
            AlbumArtUrl = artLink;
        }
    }
}