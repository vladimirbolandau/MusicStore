using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using MusicStore.Entities;
using System.Net;
using MusicStore.Models;
using Newtonsoft.Json.Linq;

namespace MusicStore.Repository
{
    public class JsonProvider : IReleasesProvider
    {
        private List<JsonReleases> releases = new List<JsonReleases>();
        public List<Album> GetTodaysReleases()
        {
            ReadJsonFile();
            List<Album> todayReleases = new List<Album>();
            foreach (var release in releases)
            {
                var tempAlbum = new Album(release.name, release.artistName, release.genres[0].name,
                    release.releaseDate, release.url, release.artworkUrl100);
                todayReleases.Add(tempAlbum);
            }
            return todayReleases;
        }

        private void ReadJsonFile()
        {
            var saveDoc = new CacheFile();
            string json = saveDoc.GetJsonFile();

            //JObject o = JObject.Parse(json);
            //IEnumerable<JToken> temp = o.SelectTokens("feed.results");
            //releases = JsonConvert.DeserializeObject<JsonReleases>(temp);

            JObject rss = JObject.Parse(json);
            JArray categories = (JArray)rss["feed"]["results"];

            var Jfile = JsonConvert.DeserializeObject<JsonFile>(json);
            releases = Jfile.feed.results;
            
        }
    }
}
