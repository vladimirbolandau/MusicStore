using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml;

namespace MusicStore.Repository
{
    class FilePath
    {
        private string direct = WebConfigurationManager.AppSettings["CacheFolderPath"];
        private string fileName = "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd");
        public string GetFilePath(string fileType)
        {
            string myDirectory = direct + fileType + "\\";
            string path = MakeFilePath(myDirectory, fileType);
            var myCache = new Cache();
            if (!File.Exists(path))
            {
                myCache.UpdateCacheByFile(fileType, path);
            }
            myCache.ClearCacheIn(myDirectory, path);
            return path;
        }
        private string MakeFilePath(string directory, string fileType)
        {
            string path = directory + fileName + "." + fileType;
            return path;
        }
    }
}
