using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    interface IAlbumsService
    {
        List<Album> LoadTodayReleases();
        List<Album> GetByDateReleases(DateTime date);
    }

    public class NewReleasesService : IAlbumsService
    {
        public List<Album> GetByDateReleases(DateTime date)
        {
            //var albums = repository.GetAlbums();

            //returns list of albums from db by date

            //additional commit
            //additional commit
            //additional commit
            //additional commit

            throw new NotImplementedException();
        }

        public List<Album> LoadTodayReleases()
        {
            //if cache exists, return list of albums created based on cached file

            //if no chache exist:
            //1. GetData from Apple Service.
            //2. SaveToDb
            //3. Save to cache file (first iteration - to xml, second - to json)

            throw new NotImplementedException();
        }
    }

    //public interface IConcertsService
    //{
    //    List<Concert> GetConcerts(string artistId);
    //}

    //public class ConcertsService : IConcertsService
    //{
    //    public List<Concert> GetConcerts(string artistId)
    //    {
    //        //switch (artistId)
    //        //    case "sdlfksjd":

    //        return new List<>();
    //    }
    //}
}
