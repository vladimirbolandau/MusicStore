using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class NewReleasesController : Controller
    {
        // GET: NewReleases
        public ActionResult Index()
        {
            IAlbumsProvider displayList = new XmlAlbumsProvider();
            displayList.GetDisplaylist();
            return View(displayList);
        }

        public ActionResult Index2()
        {
            IAlbumsProvider displayList = new XmlAlbumsProvider();
            return View(displayList);
        }
    }
}