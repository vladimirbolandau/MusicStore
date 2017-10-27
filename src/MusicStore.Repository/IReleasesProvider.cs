﻿using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository
{
    public interface IReleasesProvider
    {
        List<Album> GetTodaysReleases();
    }
}
