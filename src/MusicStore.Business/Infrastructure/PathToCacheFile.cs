using MusicStore.Entities;
using System;
using System.IO;

namespace MusicStore.Business.Infrastructure
{
    public class PathToCacheFile
    {
        private string fileName = "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".";

        public string GetFilePath(string directory, DataTransferType fileType)
        {
            string path = Path.Combine(directory, fileName) + fileType.ToString().ToLower();
            return path;
        }
    }
}
