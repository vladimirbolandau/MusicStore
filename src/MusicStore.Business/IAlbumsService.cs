using MusicStore.Entities.Dto;
using System;
using System.Collections.Generic;

namespace MusicStore.Business
{
    public interface IAlbumsService
    {
        List<AlbumDto> LoadTodayReleases();
        List<AlbumDto> GetByDateReleases(DateTime date);
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
