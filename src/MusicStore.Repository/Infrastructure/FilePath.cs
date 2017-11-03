using MusicStore.Entities;
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
    public class FilePath
    {
        private string direct = WebConfigurationManager.AppSettings["CacheFolderPath"];
        private string fileName = "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd");
        public string GetFilePath(DataTransferType fileType)
        {
            string myDirectory = Path.Combine(direct, fileType.ToString().ToLower());
            string path = MakeFilePath(myDirectory, fileType);
            var myCache = new CacheRepository();
            if (!File.Exists(path))
            {
                myCache.CreateCacheByFile(fileType, path);
            }
            myCache.ClearCacheIn(myDirectory, path);
            return path;
        }
        private string MakeFilePath(string directory, DataTransferType fileType)
        {
            return Path.Combine(directory, fileName) + "." + fileType.ToString().ToLower();
        }
    }
}
