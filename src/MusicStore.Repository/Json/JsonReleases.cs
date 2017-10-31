using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public class JsonReleases
    {
        [JsonProperty("artistUrl")]
        public string ArtistUrl { get; set; }
        [JsonProperty("artistId")]
        public string ArtistId { get; set; }
        [JsonProperty("artistName")]
        public string ArtistName { get; set; }
        [JsonProperty("artworkUrl100")]
        public string ArtworkUrl { get; set; }
        [JsonProperty("copyright")]
        public string Copyright { get; set; }
        [JsonProperty("genres")]
        public List<Genre> Genres = new List<Genre>();
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("kind")] //type (album or smth else)
        public string Kind { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class Genre
    {
        [JsonProperty("genreId")]
        public string GenreId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class JsonFile
    {
        public Feed feed { get; set; }
    }
    public class Feed
    {
        public string title { get; set; }
        public string id { get; set; }
        public Author author { get; set; }
        public List<Links> links { get; set; }
        public string copyright { get; set; }
        public string country { get; set; }
        public string icon { get; set; }
        public string updated { get; set; }
        public List<JsonReleases> results { get; set; }
    }
    public class Author
    {
        public string name { get; set; }
        public string uri { get; set; }
    }
    public class Links
    {
        public string selfAlternate { get; set; }
    }
}
