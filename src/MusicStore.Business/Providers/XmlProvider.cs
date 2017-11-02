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
        public List<AlbumMS> GetTodaysReleases()
        {
            var myPath = new FilePath();
            var myXDoc = new XmlDocument();
            myXDoc.Load(myPath.GetFilePath(fileType));
            FillDisplayList(myXDoc);

            List<AlbumMS> todayReleases = new List<AlbumMS>();
            foreach (var release in displayList)
            {
                AlbumMS tempAlbum = new AlbumMS(release.Title, release.Artist,
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
                XmlReleases tempAttr = new XmlReleases();
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
                    tempAttr.Date = tempList[8];
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