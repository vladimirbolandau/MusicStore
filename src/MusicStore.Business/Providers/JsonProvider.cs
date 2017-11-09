using System.Collections.Generic;
using System.Linq;
using System.IO;
using MusicStore.Entities;
using Newtonsoft.Json.Linq;
using MusicStore.Entities.Dto;
using MusicStore.Business.Infrastructure;
using System.Web.Configuration;
using System.Net;

namespace MusicStore.Repository
{
    public class JsonProvider : IReleasesProvider
    {
        private string direct = Path.Combine(WebConfigurationManager.AppSettings["CacheFolderPath"],
            DataTransferType.Json.ToString().ToLower());

        private List<JsonReleaseDto> releases = new List<JsonReleaseDto>();

        private bool _fileExist;

        public List<AlbumDto> GetTodayAlbums()
        {
            ReadJsonFile();
            List<AlbumDto> todayReleases = new List<AlbumDto>();
            foreach (var release in releases)
            {
                var tempAlbum = new AlbumDto(release.Name, release.ArtistName, release.Genres[0].Name,
                    release.ReleaseDate, release.Url, release.ArtworkUrl);
                todayReleases.Add(tempAlbum);
            }

            if (!_fileExist)
            {
                var dbSave = new ReleasesRepository();
                dbSave.SaveToDb(todayReleases);
            }

            return todayReleases;
        }

        private void ReadJsonFile()
        {
            var pathToCache = new PathToCacheFile();
            string path = pathToCache.GetFilePath(direct, DataTransferType.Json);

            var cacheRepository = new CacheRepository();
            _fileExist = cacheRepository.CheckFileExistence(direct, path);
            string json = GetJsonFile(_fileExist, path);
            cacheRepository.ClearCacheIn(direct, path);

            JObject jsonSearch = JObject.Parse(json);
            List<JToken> results = jsonSearch["feed"]["results"].Children().ToList();
            foreach (var result in results)
            {
                var release = result.ToObject<JsonReleaseDto>();
                releases.Add(release);
            }
        }

        private string GetJsonFile(bool fileExist, string path)
        {
            string json = null;
            if (!fileExist)
            {
                json = new WebClient()
                    .DownloadString("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
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
