using System;
using System.Collections.Generic;
using MusicStore.Repository;
using MusicStore.Entities.Dto;
using MusicStore.Business.Providers;

namespace MusicStore.Business
{
    public class NewReleasesService : IReleasesService
    {
        private readonly IReleasesProvider _releasesProvider;

        public NewReleasesService(IReleasesProvider releasesProvider)
        {
            _releasesProvider = releasesProvider;
        }

        public List<AlbumDto> GetByDateReleases(DateTime date)
        {
            //var albums = repository.GetAlbums();
            //returns list of albums from db by date
            throw new NotImplementedException();
        }

        public List<AlbumDto> LoadTodayReleases()
        {
            var listOfReleases = new List<AlbumDto>();
            listOfReleases = _releasesProvider.GetTodayAlbums();

            return listOfReleases;
        }
    }
}
