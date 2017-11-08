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
            var listOfReleases = new List<AlbumDto>();
            IReleasesProvider todayReleases = new XmlProvider();
            //IReleasesProvider todayReleases = new JsonProvider();
            listOfReleases = todayReleases.GetTodayAlbums();

            var dbSave = new ReleasesRepository();
            dbSave.SaveToDb(listOfReleases);

            return listOfReleases;
        }
    }
}
