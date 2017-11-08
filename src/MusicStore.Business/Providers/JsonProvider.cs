using System.Collections.Generic;
using System.Linq;
using System.IO;
using MusicStore.Entities;
using Newtonsoft.Json.Linq;
using MusicStore.Entities.Dto;
using MusicStore.Business.Infrastructure;
using System.Web.Configuration;

namespace MusicStore.Repository
{
    public class JsonProvider : IReleasesProvider
    {
        private string direct = Path.Combine(WebConfigurationManager.AppSettings["CacheFolderPath"],
            DataTransferType.Json.ToString().ToLower());

        private List<JsonReleaseDto> releases = new List<JsonReleaseDto>();

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
            return todayReleases;
        }
        private void ReadJsonFile()
        {
            var pathToCache = new PathToCacheFile();
            string path = pathToCache.GetFilePath(direct, DataTransferType.Json);

            var cacheRepository = new CacheRepository();
            cacheRepository.CheckFileExistence(direct, path, DataTransferType.Json);

            string json = File.ReadAllText(path);
            JObject googleSearch = JObject.Parse(json);
            List<JToken> results = googleSearch["feed"]["results"].Children().ToList();
            foreach (var result in results)
            {
                var release = result.ToObject<JsonReleaseDto>();
                releases.Add(release);
            }
        }
    }
}
