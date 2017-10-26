using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Configuration;

namespace MusicStore.Models
{
    public class CacheFile
    {
        private string direct = WebConfigurationManager.AppSettings["CacheFolderPath"];
        public XmlDocument GetXmlFile()
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
        private void ClearCache(string exceptFile)
        {
            foreach (var file in Directory.GetFiles(direct))
                if (file != exceptFile)
                    File.Delete(file);
        }
        private string GetXmlPath(string direct)
        {
            string path = direct + "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".xml";
            return path;
        }
    }
}