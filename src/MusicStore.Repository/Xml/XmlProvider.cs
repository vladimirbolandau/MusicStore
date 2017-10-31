using MusicStore.Entities;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace MusicStore.Repository
{
    public class XmlProvider : IReleasesProvider
    {
        private List<XmlReleases> displayList = new List<XmlReleases>();
        private string fileType = "xml";
        public List<Album> GetTodaysReleases()
        {
            var myPath = new FilePath();
            var urlDoc = new XmlDocument();
            urlDoc.Load(myPath.GetFilePath(fileType));
            FillDisplayList(urlDoc);

            List<Album> todayReleases = new List<Album>();
            foreach (var release in displayList)
            {
                Album tempAlbum = new Album(release.title, release.artist,
                    release.genre, release.date, release.link, release.guid);
                todayReleases.Add(tempAlbum);
            }
            return todayReleases;
        }
        private void FillDisplayList(XmlDocument xDoc)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot.SelectNodes("//item"))
            {
                XmlReleases tempAttr = new XmlReleases();
                List<string> tempList = new List<string>();
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Attributes.Count > 0)
                    {
                        XmlNode attr = childnode.Attributes.GetNamedItem("domain");
                        if (attr != null)
                            tempAttr.artistLink = attr.Value;
                    }
                    tempList.Add(childnode.InnerText);
                }
                tempAttr.fullTitle = tempList[0];
                tempAttr.artist = tempList[1];
                tempAttr.link = tempList[2];
                tempAttr.guid = tempList[3];
                tempAttr.title = tempList[4];
                tempAttr.category = char.ToUpper((tempList[5])[0]) + tempList[5].Substring(1);
                tempAttr.genre = tempList[6];
                tempAttr.format = tempList[7];
                try
                {
                    tempAttr.date = tempList[8];
                }
                catch (Exception)
                {
                    tempAttr.date = "No Date";
                }
                displayList.Add(tempAttr);
            }
        }
    }
}