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
    public class CacheFile
    {
        private string direct = WebConfigurationManager.AppSettings["CacheFolderPath"];
        public XmlDocument GetXmlFile()
        {
            XmlDocument tempDoc = new XmlDocument();
            string path = GetXmlPath(direct + "XML\\");
            try
            {
                tempDoc.Load(path);
            }
            catch (Exception)
            {
                tempDoc.Load("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.rss");
                var appleProvider = new AppleiTunesProvider(tempDoc);
                tempDoc.Save(path);
            }
            ClearCacheIn(direct + "XML\\", path);
            return tempDoc;
        }
        public string GetJsonFile()
        {
            string path = GetJsonPath(direct + "JSON\\");
            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (Exception)
            {
                json = new WebClient().DownloadString(
                    "https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.json");
                File.WriteAllText(path, json);
            }
            ClearCacheIn(direct + "JSON\\", path);
            return json;
        }
        private void ClearCacheIn(string directory, string exceptFile)
        {
            foreach (var file in Directory.GetFiles(directory))
                if (file != exceptFile)
                    File.Delete(file);
        }
        private string GetXmlPath(string direct)
        {
            string path = direct + "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".xml";
            return path;
        }
        private string GetJsonPath(string direct)
        {
            string path = direct + "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".json";
            return path;
        }
    }
}