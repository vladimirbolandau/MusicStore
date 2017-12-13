using MusicStore.Models;
using MusicStore.Business;
using System.Collections.Generic;
using System.Web.Mvc;

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
            var release = new NewReleasesModel();
            List<NewReleasesModel> releaseList = release.ToViewModel(_albumsService.LoadTodayReleases());
            return View(releaseList);
        }
    }
}