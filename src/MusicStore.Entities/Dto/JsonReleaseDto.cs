using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusicStore.Repository
{
    public class JsonReleaseDto
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

        [JsonProperty("kind")]
        public string Kind { get; set; } //type (album or smth else) 

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
}
