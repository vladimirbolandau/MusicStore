using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public interface IAlbumsService
    {
        List<Album> LoadTodayReleases();
        List<Album> GetByDateReleases(DateTime date);
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
