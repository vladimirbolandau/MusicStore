using MusicStore.Models;
using MusicStore.Business;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class NewReleasesController : Controller
    {
        // GET: NewReleases
        public ActionResult Index()
        {
            IAlbumsService albumsProvider = new NewReleasesService();
            var release = new NewReleasesModel();
            List<NewReleasesModel> releaseList = release.GetReleasesList(albumsProvider.LoadTodayReleases());
            return View(releaseList);
        }
    }
}