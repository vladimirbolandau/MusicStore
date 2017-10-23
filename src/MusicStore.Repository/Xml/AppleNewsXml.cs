using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class NewReleasesXml
    {
        public string fullTitle { get; set; }
        public string artistLink { get; set; }
        public string artist { get; set; }
        public string link { get; set; }
        public string guid { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string genre { get; set; }
        public string format { get; set; }
        public string date { get; set; }
    }
}