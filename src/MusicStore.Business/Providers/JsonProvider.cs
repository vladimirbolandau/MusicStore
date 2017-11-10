using System.Collections.Generic;
using System.Linq;
using System.IO;
using MusicStore.Entities;
using Newtonsoft.Json.Linq;
using MusicStore.Entities.Dto;
using MusicStore.Business.Infrastructure;
using System.Web.Configuration;
using System.Net;
using MusicStore.Repository;
using System.Text;

namespace MusicStore.Business.Providers
{
    public class JsonProvider : IReleasesProvider
    {
        private string direct = Path.Combine(WebConfigurationManager.AppSettings["CacheFolderPath"],
            DataTransferType.Json.ToString().ToLower());

        private bool _fileExists;

        public List<AlbumDto> GetTodayAlbums()
        {
            IEnumerable<JsonReleaseDto> jsonReleases = GetJsonReleases();
            List<AlbumDto> todayReleases = new List<AlbumDto>();
            foreach (JsonReleaseDto jsonRelease in jsonReleases)
            {
                var tempAlbum = new AlbumDto(jsonRelease.Name, jsonRelease.ArtistName, jsonRelease.Genres[0].Name,
                    jsonRelease.ReleaseDate, jsonRelease.Url, jsonRelease.ArtworkUrl);
                todayReleases.Add(tempAlbum);
            }

            if (!_fileExists)
            {
                var dbSave = new ReleasesRepository();
                dbSave.Save(todayReleases);
            }

            return todayReleases;
        }

        private IEnumerable<JsonReleaseDto> GetJsonReleases()
        {
            var pathToCache = new PathToCacheFile();
            string path = pathToCache.GetFilePath(direct, DataTransferType.Json);

            var cacheRepository = new CacheRepository();
            _fileExists = cacheRepository.DoesFileForTodayExists(direct, path);
            string json = GetJsonFile(_fileExists, path);
            cacheRepository.ClearCacheIn(direct, path);

            JObject jsonSearch = JObject.Parse(json);
            List<JToken> results = jsonSearch["feed"]["results"].Children().ToList();
            foreach (JToken result in results)
            {
                var release = result.ToObject<JsonReleaseDto>();
                yield return release;
            }
        }

        private string GetJsonFile(bool fileExists, string path)
        {
            string json = null;
            if (!fileExists)
            {
                var jsonWeb = new WebClient()
                    .DownloadString("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
                byte[] data = Encoding.Default.GetBytes(jsonWeb);
                json = Encoding.UTF8.GetString(data);
                File.WriteAllText(path, json);
            }
            else
            {
                json = File.ReadAllText(path);
            }
            return json;
        }
    }
}
