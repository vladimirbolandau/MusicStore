using System;
using System.Collections.Generic;
using MusicStore.Repository;
using MusicStore.Entities.Dto;

namespace MusicStore.Business
{
    public class NewReleasesService : IAlbumsService
    {
        public List<AlbumDto> GetByDateReleases(DateTime date)
        {
            //var albums = repository.GetAlbums();
            //returns list of albums from db by date
            throw new NotImplementedException();
        }

        public List<AlbumDto> LoadTodayReleases()
        {
            IReleasesProvider todayReleases = new XmlProvider();
            //IReleasesProvider todayReleases = new JsonProvider();

            var listOfReleases = new List<AlbumDto>();
            listOfReleases = todayReleases.GetTodayAlbums();

            return listOfReleases;
        }
    }
}
