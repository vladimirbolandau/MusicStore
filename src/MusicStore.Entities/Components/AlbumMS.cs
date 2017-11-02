using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MusicStore.Entities
{
    public class AlbumMS
    {
        public string Name { get; set; }
        public ArtistMS Artist { get; set; }
        public GenreMS Genre { get; set; }
        public DateTime DateRelease { get; set; }
        public string AlbumLink { get; set; }
        public string AlbumArtUrl { get; set; }
        public AlbumMS()
        {
            Name = "No Album";
            Artist = new ArtistMS();
            Genre = new GenreMS();
            DateRelease = new DateTime();
            AlbumLink = "No Link";
            AlbumArtUrl = "No URL";
        }
        public AlbumMS(string name, string artistName, string genreName,
            string dateRelease, string albumLink, string artLink)
        {
            Name = name;
            Artist = new ArtistMS(artistName);
            Genre = new GenreMS(genreName);
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