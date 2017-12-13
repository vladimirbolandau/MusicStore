using MusicStore.Business.Infrastructure;
using MusicStore.Entities;
using MusicStore.Entities.Dto;
using MusicStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Configuration;
using System.Xml;

namespace MusicStore.Business.Providers
{
    public class XmlProvider : IReleasesProvider
    {
        private readonly IReleasesRepository _releasesRepository;

        private readonly ICacheRepository _cacheRepository;

        public XmlProvider(IReleasesRepository releasesRepository, ICacheRepository cacheRepository)
        {
            _releasesRepository = releasesRepository;
            _cacheRepository = cacheRepository;
        }

        public List<AlbumDto> GetTodayAlbums()
        {
            string direct = Path.Combine(WebConfigurationManager.AppSettings["CacheFolderPath"],
                DataTransferType.Xml.ToString().ToLower());
            var pathToCache = new PathToCacheFile();
            string path = pathToCache.GetFilePath(direct, DataTransferType.Xml);
            
            bool fileForTodayExists = _cacheRepository.DoesFileForTodayExists(path);

            var cacheFile = new CacheFile();
            if (!fileForTodayExists)
            {
                cacheFile.CreateCacheFile(path, DataTransferType.Xml);
            }
            var xmlDocInString = cacheFile.GetCacheFile(path);

            _cacheRepository.ClearCacheIn(direct, path);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlDocInString);
            IEnumerable<XmlReleaseDto> xmlReleases = FillDisplayList(xmlDoc);

            List<AlbumDto> todayReleases = new List<AlbumDto>();
            foreach (XmlReleaseDto xmlRelease in xmlReleases)
            {
                AlbumDto tempAlbum = new AlbumDto(xmlRelease.Title, xmlRelease.Artist,
                    xmlRelease.Genre, xmlRelease.Date, xmlRelease.Link, xmlRelease.Guid);
                todayReleases.Add(tempAlbum);
            }

            if (!fileForTodayExists)
            {
                _releasesRepository.Save(todayReleases);
            }

            return todayReleases;
        }

        private IEnumerable<XmlReleaseDto> FillDisplayList(XmlDocument xDoc)
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
                tempAttr.Category = tempList[5];
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
                yield return tempAttr;
            }
            // return displayList;
        }
    }
}