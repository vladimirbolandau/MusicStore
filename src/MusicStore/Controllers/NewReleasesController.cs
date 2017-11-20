using MusicStore.Models;
using MusicStore.Business;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class NewReleasesController : Controller
    {
        private readonly IAlbumsService _albumsService;

        //public NewReleasesController(IAlbumsService albumsService)
        //{
        //    _albumsService = albumsService;
        //}

        // GET: NewReleases
        public ActionResult Index()
        {
            //IAlbumsService _albumsService = new NewReleasesService();
            var release = new NewReleasesModel();
            List<NewReleasesModel> releaseList = release.GetReleasesList(_albumsService.LoadTodayReleases());
            return View(releaseList);
        }
    }
}