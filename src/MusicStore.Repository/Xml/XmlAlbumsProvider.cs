using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace MusicStore.Models
{
    public class XmlAlbumsProvider
    {
        private List<AppleNewsXml> displayList;
        public XmlAlbumsProvider()
        {
            displayList = new List<AppleNewsXml>();
        }
        public List<AppleNewsXml> GetTodaysReleases()
        {
            CacheFile saveDoc = new CacheFile();
            XmlDocument urlDoc = saveDoc.GetXmlFile();
            FillDisplayList(urlDoc);

            return displayList;
        }
        private void FillDisplayList(XmlDocument xDoc)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot.SelectNodes("//item"))
            {
                AppleNewsXml tempAttr = new AppleNewsXml();
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