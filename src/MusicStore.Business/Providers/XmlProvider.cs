using MusicStore.Business.Infrastructure;
using MusicStore.Entities;
using MusicStore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Configuration;
using System.Xml;

namespace MusicStore.Repository
{
    public class XmlProvider : IReleasesProvider
    {
        private string direct = Path.Combine(WebConfigurationManager.AppSettings["CacheFolderPath"],
            DataTransferType.Xml.ToString().ToLower());

        private List<XmlReleaseDto> displayList = new List<XmlReleaseDto>();

        public List<AlbumDto> GetTodayAlbums()
        {
            var pathToCache = new PathToCacheFile();
            string path = pathToCache.GetFilePath(direct, DataTransferType.Xml);

            var cacheRepository = new CacheRepository();
            cacheRepository.CheckFileExistence(direct, path, DataTransferType.Xml);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            FillDisplayList(xmlDoc);

            List<AlbumDto> todayReleases = new List<AlbumDto>();
            foreach (var release in displayList)
            {
                AlbumDto tempAlbum = new AlbumDto(release.Title, release.Artist,
                    release.Genre, release.Date, release.Link, release.Guid);
                todayReleases.Add(tempAlbum);
            }
            return todayReleases;
        }
        private void FillDisplayList(XmlDocument xDoc)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot.SelectNodes("//item"))
            {
                XmlReleaseDto tempAttr = new XmlReleaseDto();
                List<string> tempList = new List<string>();
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Attributes.Count > 0)
                    {
                        XmlNode attr = childnode.Attributes.GetNamedItem("domain");
                        if (attr != null)
                            tempAttr.ArtistLink = attr.Value;
                    }
                    tempList.Add(childnode.InnerText);
                }
                tempAttr.FullTitle = tempList[0];
                tempAttr.Artist = tempList[1];
                tempAttr.Link = tempList[2];
                tempAttr.Guid = tempList[3];
                tempAttr.Title = tempList[4];
                tempAttr.Category = char.ToUpper((tempList[5])[0]) + tempList[5].Substring(1);
                tempAttr.Genre = tempList[6];
                tempAttr.Format = tempList[7];
                try
                {
                    tempAttr.Date = tempList[tempList.Count - 1];
                }
                catch (Exception)
                {
                    tempAttr.Date = "No Date";
                }
                displayList.Add(tempAttr);
            }
        }
    }
}