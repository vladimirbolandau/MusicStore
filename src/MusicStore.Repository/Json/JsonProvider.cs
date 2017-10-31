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
        private string fileType = "json";
        public List<Album> GetTodaysReleases()
        {
            ReadJsonFile();
            List<Album> todayReleases = new List<Album>();
            foreach (var release in releases)
            {
                var tempAlbum = new Album(release.Name, release.ArtistName, release.Genres[0].Name,
                    release.ReleaseDate, release.Url, release.ArtworkUrl);
                todayReleases.Add(tempAlbum);
            }
            return todayReleases;
        }
        private void ReadJsonFile()
        {
            var myPath = new FilePath();
            string json = File.ReadAllText(myPath.GetFilePath(fileType));
            //string json = saveDoc.GetJsonFile();

            //JObject o = JObject.Parse(json);
            //IEnumerable<JToken> temp = o.SelectTokens("feed.results");
            //releases = JsonConvert.DeserializeObject<JsonReleases>(temp);

            //JObject rss = JObject.Parse(json);
            //JArray categories = (JArray)rss["feed"]["results"];


            var Jfile = JsonConvert.DeserializeObject<JsonFile>(json);
            releases = Jfile.feed.results;
            
        }
    }
}
