using System;
using System.Collections.Generic;
using MusicStore.Repository;
using MusicStore.Entities.Dto;
using MusicStore.Business.Providers;

namespace MusicStore.Business
{
    public class NewReleasesService : IAlbumsService
    {
        private readonly IReleasesProvider _todayReleases;

        public NewReleasesService(IReleasesProvider todayReleases)
        {
            _todayReleases = todayReleases;
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
            listOfReleases = _todayReleases.GetTodayAlbums();

            return listOfReleases;
        }
    }
}
