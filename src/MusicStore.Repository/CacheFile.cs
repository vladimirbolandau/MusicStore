using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace MusicStore.Models
{
    public class CacheFile
    {
        private string direct = @"C:\Users\vbolandau\Documents\Visual Studio 2015\Projects\MusicStore\MusicStore\Cache\";
        public XmlDocument RecreateXmlFile()
        {
            XmlDocument tempDoc = new XmlDocument();
            string path = GetXmlPath(direct);
            try
            {
                tempDoc.Load(path);
            }
            catch (Exception)
            {
                tempDoc.Load("https://rss.itunes.apple.com/api/v1/us/apple-music/new-releases/all/50/explicit.rss");
                tempDoc.Save(path);
            }
            ClearCache(path);
            return tempDoc;
        }
        private void ClearCache(string exception)
        {
            foreach (var file in Directory.GetFiles(direct))
                if (file != exception)
                    File.Delete(file);
        }
        private string GetXmlPath(string direct)
        {
            string path = direct + "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".xml";
            return path;
        }
    }
}