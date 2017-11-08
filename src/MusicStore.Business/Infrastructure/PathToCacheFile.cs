using MusicStore.Entities;
using MusicStore.Repository;
using System;
using System.IO;
using System.Web.Configuration;

namespace MusicStore.Business.Infrastructure
{
    public class PathToCacheFile
    {
        //private string direct = WebConfigurationManager.AppSettings["CacheFolderPath"];

        private string fileName = "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".";

        public string GetFilePath(string directory, DataTransferType fileType)
        {
            //string directory = Path.Combine(direct, fileType.ToString().ToLower());
            //string path = MakeFilePath(directory, fileType);

            string path = Path.Combine(directory, fileName) + fileType.ToString().ToLower();

            //var cacheRepository = new CacheRepository();
            //cacheRepository.CheckFileExistence(directory, path, fileType);

            return path;
        }

        //private string MakeFilePath(string directory, DataTransferType fileType)
        //{
        //    return Path.Combine(directory, fileName) + fileType.ToString().ToLower();
        //}
    }
}
