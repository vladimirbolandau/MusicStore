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
            CacheFile saveDoc = new CacheFile();
            string json = saveDoc.GetJsonFile();
            JsonFile Jfile = JsonConvert.DeserializeObject<JsonFile>(json);
            releases = Jfile.feed.results;

            //File.WriteAllText("TodayReleases.2017.10.27.json", data);
        }
    }
}
