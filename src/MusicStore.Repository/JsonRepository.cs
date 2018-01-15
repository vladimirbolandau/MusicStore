using System.Net;
using System.Text;

namespace MusicStore.Repository
{
    public class JsonRepository : IJsonRepository
    {
        public string LoadDataFromApi() //Load JSON File
        {
            string json = null;
            var jsonWeb = new WebClient()
                .DownloadString("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
            //For reading JSON file correct in UTF8 coding
            //Another commit
            //Master
            byte[] data = Encoding.Default.GetBytes(jsonWeb);
            json = Encoding.UTF8.GetString(data);
            return json;
        }
    }
}
