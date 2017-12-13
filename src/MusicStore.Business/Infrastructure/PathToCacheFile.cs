using MusicStore.Entities;
using System;
using System.IO;

namespace MusicStore.Business.Infrastructure
{
    public class PathToCacheFile
    {
        public string GetFilePath(string directory, DataTransferType fileType)
        {
            string fileName = GetFileName();
            string path = Path.Combine(directory, fileName) + fileType.ToString().ToLower();
            return path;
        }

        private string GetFileName()
        {
            return "TodayReleases." + DateTime.Now.ToString("yyyy.MM.dd") + ".";
        }
    }
}
