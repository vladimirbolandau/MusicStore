using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Entities;
using MusicStore.Repository;
using MusicStore.Entities.DbModels;

namespace MusicStore.Business
{
    public class NewReleasesService : IAlbumsService
    {
        public List<AlbumMS> GetByDateReleases(DateTime date)
        {
            //var albums = repository.GetAlbums();
            //returns list of albums from db by date
            throw new NotImplementedException();
        }

        public List<AlbumMS> LoadTodayReleases()
        {
            //if cache exists, return list of albums created based on cached file
            var listOfReleases = new List<AlbumMS>();
            //IReleasesProvider todayReleases = new XmlProvider();
            IReleasesProvider todayReleases = new JsonProvider();
            listOfReleases = todayReleases.GetTodaysReleases();

            //using (var ctx = new MusicStoreDBEntities())
            //{
            //    foreach (var release in listOfReleases)
            //    {
            //        var dbRelease = new Release()
            //        {
            //            Date = DateTime.Today,
            //            Album = new Album()
            //            {
            //                Name = release.Name,
            //                DateRelease = release.DateRelease,
            //                AlbumArtUrl = release.AlbumArtUrl,
            //                LinkToiTunes = release.AlbumLink,
            //                Artist = new Artist() { Name = release.Artist.Name },
            //                Genre = new Entities.DbModels.Genre() { Name = release.Genre.Name }
            //            }
            //        };
            //        //if exist pass, if not - add
            //        if (!ctx.Releases.Contains(dbRelease))
            //        {
            //            ctx.Releases.Add(dbRelease);
            //            ctx.SaveChanges();
            //        }
            //    }
            //}

            //if no chache exist:
            //1. GetData from Apple Service.
            //2. SaveToDb
            //3. Save to cache file (first iteration - to xml, second - to json)
            return listOfReleases;
        }
    }
}
