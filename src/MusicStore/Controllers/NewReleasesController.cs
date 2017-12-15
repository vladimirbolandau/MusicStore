using MusicStore.Models;
using MusicStore.Business;
using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Entities.Dto;

namespace MusicStore.Controllers
{
    public class NewReleasesController : Controller
    {
        private readonly IReleasesService _albumsService;

        public NewReleasesController(IReleasesService albumsService)
        {
            _albumsService = albumsService;
        }

        // GET: NewReleases
        public ViewResult Index()
        {
            return View(ToViewModel(_albumsService.LoadTodayReleases()));
        }

        public List<NewReleasesModel> ToViewModel(List<AlbumDto> albumsList)
        {
            List<NewReleasesModel> ReleasesList = new List<NewReleasesModel>();
            foreach (var album in albumsList)
            {
                NewReleasesModel tempRelease = new NewReleasesModel(album);
                ReleasesList.Add(tempRelease);
            }
            return ReleasesList;
        }
    }
}