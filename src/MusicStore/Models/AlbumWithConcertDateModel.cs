using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class AlbumWithConcertDateModel
    {
        List<AlbumViewModel> Albums { get; set; }
        List<Concerts> Concerts { get; set; }
    }

    public class AlbumViewModel
    {
        private DateTime? releaseDate;
        public string Album { get; set; }
        public string Artist { get; set; }
        public DateTime? ReleaseDate { set { releaseDate = value; } }
        public string ReleaseDateRepresentation { get { return releaseDate == null ? "No Date" : releaseDate.Value.ToShortDateString(); } }
    }
}