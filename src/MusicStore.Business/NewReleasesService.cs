using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Entities;
using MusicStore.Repository;

namespace MusicStore.Business
{
    public class NewReleasesService : IAlbumsService
    {
        public List<Album> GetByDateReleases(DateTime date)
        {
            //var albums = repository.GetAlbums();
            //returns list of albums from db by date
            throw new NotImplementedException();
        }

        public List<Album> LoadTodayReleases()
        {
            //if cache exists, return list of albums created based on cached file
            IReleasesProvider todayReleases = new XmlProvider();
            List<Album> listOfReleases = todayReleases.GetTodaysReleases();

            //if no chache exist:
            //1. GetData from Apple Service.
            //2. SaveToDb
            //3. Save to cache file (first iteration - to xml, second - to json)
            return listOfReleases;
        }
    }
}
