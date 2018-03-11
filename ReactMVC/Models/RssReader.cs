using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ReactMVC.Models {
    /// <summary>
    /// The class instantiates a new WebClient and gets RSS feed from the specified source (URL) with the specified encoding.
    /// </summary>
    public class RssReader {
        /// <summary>
        /// Model schema for RSS, including Title, Description, Link and Published date
        /// </summary>
        public class Rss {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
            public string PubDate { get; set; }
        }

        /// <summary>Gets XML output from a specified RSS feed. 
        /// The correct encoding is determined at runtime by invoking the Encoding.GetEncoding(1251).GetString(data);.
        /// </summary> 
        /// <returns>IEnumarable list of <Rss> objects</Rss></returns>
        public static IEnumerable<Rss> GetRssFeeds(string url, int codepage)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
           
            var xmlData = client.DownloadString(url);  //remember to update this URL
                                                       //var xmlData = Encoding.GetEncoding(codepage).GetString(data);
  //var xmlData = Encoding.GetEncoding(codepage).GetString(data);

               var settings = new XmlReaderSettings()
                {
                    IgnoreWhitespace = true,
                    CheckCharacters = true,
                    CloseInput = true,
                    IgnoreComments = true,
                    IgnoreProcessingInstructions = true
                };
          

            //using (XmlReader reader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(xmlData)), settings))
            //{
                //var xmlData = Encoding.GetEncoding(codepage).GetString(data);

                XDocument xml = XDocument.Parse(xmlData);

                var feeds = (from story in xml.Descendants("item")
                             select new Rss
                             {
                                 Title = ((string)story.Element("title")),
                                 Link = ((string)story.Element("link")),
                                 Description = ((string)story.Element("description")),
                                 PubDate = ((string)story.Element("pubDate"))
                             }).Take(10);

                return feeds;
            //}
          
        }
        /// <summary>
        /// Dummy method for demo purposes
        /// </summary>
        /// <returns>null</returns>
        public static IEnumerable<Rss> Get()
        {
            return null;
        }

    }
}