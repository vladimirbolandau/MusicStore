using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class JsonReleases
    {
        public string artistUrl { get; set; }
        public string artistId { get; set; }
        public string artistName { get; set; }
        public string artworkUrl100 { get; set; }
        public string copyright { get; set; }
        public List<Genre> genres = new List<Genre>();
        public string id { get; set; }
        public string kind { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
        public string url { get; set; }
    }
    public class Genre
    {
        public string genreId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}
