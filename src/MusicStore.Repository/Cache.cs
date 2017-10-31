using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Configuration;
using MusicStore.Repository;
using System.Net;

namespace MusicStore.Models
{
    public class Cache
    {
        public void ClearCacheIn(string directory, string exceptFile)
        {
            foreach (var file in Directory.GetFiles(directory))
                if (file != exceptFile)
                    File.Delete(file);
        }
        public void UpdateCacheByFile(string type, string path)
        {
            switch (type)
            {
                case "xml":
                    var tempDoc = new XmlDocument();
                    tempDoc.Load(
                        "https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.rss");
                    var appleProvider = new AppleiTunesProvider(tempDoc);
                    tempDoc.Save(path);
                    break;
                case "json":
                    var json = new WebClient().DownloadString(
                        "https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
                    File.WriteAllText(path, json);
                    break;
                default:
                    break;
            }
        }
    }
}