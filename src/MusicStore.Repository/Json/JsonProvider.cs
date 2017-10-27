using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using MusicStore.Entities;

namespace MusicStore.Repository
{
    public class JsonProvider : IReleasesProvider
    {
        private List<JsonReleases> releases = new List<JsonReleases>();
        public List<Album> GetTodaysReleases()
        {
            List<Album> todayReleases = new List<Album>();
            foreach (var release in releases)
            {
                var tempRelease = new Album();

                todayReleases.Add(tempRelease);
            }
            return todayReleases;
        }

        public void ReadJsonFile()
        {
            string JSONstring = File.ReadAllText(
                "https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //AppleNewsJson album = ser.Deserialize<AppleNewsJson>(JSONstring);
            releases = JsonConvert.DeserializeObject<List<JsonReleases>>(JSONstring);

            //File.WriteAllText("TodayReleases.2017.10.27.json", JSONstring);
            string data = JsonConvert.SerializeObject(releases);
            File.WriteAllText("TodayReleases.2017.10.27.json", data);
        }
    }
}
