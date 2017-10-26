﻿using MusicStore.Models;
using MusicStore.Business;
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
            IAlbumsService albumsProvider = new NewReleasesService();
            NewReleasesModel release = new NewReleasesModel();
            List<NewReleasesModel> releaseList = release.GetReleasesList(albumsProvider.LoadTodayReleases());
            return View(releaseList);
        }
    }
}