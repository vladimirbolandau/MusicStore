using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Entities;

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
            var todayReleases = new XmlAlbumsProvider();
            //todayReleases.GetTodaysReleases();
            List<Album> listOfReleases = new List<Album>();
            foreach (var release in todayReleases.GetTodaysReleases())
            {
                Album tempAlbum = new Album(release.title, release.artist, release.genre, release.date, release.link);
                listOfReleases.Add(tempAlbum);
            }

            //if no chache exist:
            //1. GetData from Apple Service.
            //2. SaveToDb
            //3. Save to cache file (first iteration - to xml, second - to json)
            return listOfReleases;
        }
    }
}
