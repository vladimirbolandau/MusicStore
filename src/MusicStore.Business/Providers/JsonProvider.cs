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
        private bool _fileExists;

        private readonly IReleasesRepository _releasesRepository;

        private readonly ICacheRepository _cacheRepository;

        private readonly IJsonRepository _jsonRepository;

        public JsonProvider(IReleasesRepository releasesRepository, ICacheRepository cacheRepository, IJsonRepository jsonRepository)
        {
            _releasesRepository = releasesRepository;
            _cacheRepository = cacheRepository;
            _jsonRepository = jsonRepository;
        }

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
                _releasesRepository.Save(todayReleases);
            }

            return todayReleases;
        }

        private IEnumerable<JsonReleaseDto> GetJsonReleases()
        {
            string direct = Path.Combine(WebConfigurationManager.AppSettings["CacheFolderPath"],
                DataTransferType.Json.ToString().ToLower());
            var pathToCache = new PathToCacheFile();
            string path = pathToCache.GetFilePath(direct, DataTransferType.Json);
            
            _fileExists = _cacheRepository.DoesFileExists(path);
            if (!_fileExists)
            {
                var fileContents = _jsonRepository.LoadDataFromApi();
                _cacheRepository.CreateCacheFile(path, fileContents);
            }
            string json = _cacheRepository.GetCacheFile(path);
            _cacheRepository.ClearCacheIn(direct, path);

            JObject jsonSearch = JObject.Parse(json);
            List<JToken> results = jsonSearch["feed"]["results"].Children().ToList();
            foreach (JToken result in results)
            {
                var release = result.ToObject<JsonReleaseDto>();
                yield return release;
            }
        }
    }
}
