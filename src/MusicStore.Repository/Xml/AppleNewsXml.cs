using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class AppleNewsXml
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
        //public List<string> GetAlbumAccessories()
        //{
        //    List<string> albumAccessories = new List<string>();
        //    albumAccessories.Add(title);
        //    return albumAccessories;
        //}
        //public string[] GetAlbumAccessories()
        //{
        //    string[] albumAccessories = { title, artist, genre, date, link };
        //    return albumAccessories;
        //}
    }
}