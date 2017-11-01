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
            JObject googleSearch = JObject.Parse(json);
            List<JToken> results = googleSearch["feed"]["results"].Children().ToList();
            foreach (var result in results)
            {
                var release = result.ToObject<JsonReleases>();
                releases.Add(release);
            }
        }
    }
}
