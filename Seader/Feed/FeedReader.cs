using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net;
using System.IO;

namespace Seader.Feed
{
    /// <summary>
    /// フィードを読み込みます。
    /// </summary>
    public class FeedReader
    {
        /// <summary>
        /// RSSの読み込みを行います。
        /// </summary>
        /// <param name="uri">フィードのURL</param>
        /// <param name="userAgent">偽装するユーザーエージェント</param>
        /// <returns>フィード</returns>
        public FeedInfo Read(Uri uri, string userAgent = null)
        {
            FeedInfo info = null;

            XmlDocument rssXml = new XmlDocument();
            try
            {
                if (userAgent == null || userAgent.Length == 0)
                {
                    rssXml.Load(uri.ToString());
                }
                else
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.ToString());
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string content = reader.ReadToEnd();
                        rssXml.LoadXml(content);
                    }
                }
            }
            catch (System.Net.WebException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            XmlElement element = rssXml.DocumentElement;

            string nodeTag = element.Name;
            if (nodeTag == "rdf:RDF")
            {
                info = ReadRSS1(uri, rssXml);
            }
            else if (nodeTag == "rss")
            {
                info = ReadRSS2(uri);
            }

            return info;
        }

        /// <summary>
        /// RSS 1.0の読み込みを行います。
        /// </summary>
        /// <param name="uri">フィードのURL</param>
        /// <param name="rssXml">読み込み済みのXMLドキュメント</param>
        /// <returns>フィード</returns>
        private FeedInfo ReadRSS1(Uri uri, XmlDocument rssXml)
        {
            FeedInfo info = new FeedInfo();
            info.Url = uri;

            List<FeedItem> ret = new List<FeedItem>();

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXml.NameTable);
            nsmgr.AddNamespace("rss", "http://purl.org/rss/1.0/");
            nsmgr.AddNamespace("content", "http://purl.org/rss/1.0/modules/content/");
            nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

            XmlNodeList linodes = rssXml.SelectNodes("/rdf:RDF/rss:channel/rss:items/rdf:Seq/rdf:li", nsmgr);

            foreach (XmlNode node in linodes)
            {
                string strResource = node.Attributes["resource", "http://www.w3.org/1999/02/22-rdf-syntax-ns#"].Value;

                XmlNode aboutItem = rssXml.SelectSingleNode("/rdf:RDF/rss:item[@rdf:about='" + strResource + "']", nsmgr);

                if (aboutItem != null)
                {
                    XmlNode titleNode = aboutItem.SelectSingleNode("rss:title", nsmgr);
                    XmlNode contentNode = aboutItem.SelectSingleNode("content:encoded", nsmgr);
                    XmlNode linkUrkNode = aboutItem.SelectSingleNode("rss:link", nsmgr);
                    XmlNode dateNode = aboutItem.SelectSingleNode("dc:date", nsmgr);

                    string title = string.Empty;
                    string content = string.Empty;
                    string link = string.Empty;
                    string date = string.Empty;

                    if (titleNode != null)
                    {
                        title = titleNode.InnerText;
                    }
                    if (linkUrkNode != null)
                    {
                        link = linkUrkNode.InnerText;
                    }
                    if (contentNode != null)
                    {
                        content = contentNode.InnerText;
                    }
                    if (dateNode != null)
                    {
                        date = dateNode.InnerText;
                    }

                    FeedItem rssItem = new FeedItem();
                    rssItem.Title = title;
                    rssItem.Content = content;
                    rssItem.Date = stringToDateTime(date);
                    rssItem.Link = new Uri(link);
                    ret.Add(rssItem);
                }
            }
            info.Items = ret.ToArray();
            info.Title = rssXml.SelectSingleNode("/rdf:RDF/rss:channel/rss:title", nsmgr).InnerText;
            return info;
        }

        /// <summary>
        /// RSS 2.0の読み込みを行います。
        /// </summary>
        /// <param name="uri">フィードのURL</param>
        /// <returns>フィード</returns>
        private FeedInfo ReadRSS2(Uri uri)
        {
            using (var reader = XmlReader.Create(uri.AbsoluteUri))
            {
                var feed = SyndicationFeed.Load(reader);
                return new FeedInfo
                {
                    Url = uri,
                    Title = feed.Title.Text,
                    Description = feed.Description.Text,
                    Items = (from item in feed.Items
                             let link = item.Links.FirstOrDefault() ?? new SyndicationLink(new Uri("about:blank"))
                             select new FeedItem
                             {
                                 Title = item.Title.Text,
                                 Content = item.Content == null ? null : item.Content.ToString(),
                                 Summary = item.Summary == null ? null : item.Summary.Text,
                                 Date = item.PublishDate.DateTime,
                                 Link = link.Uri
                             }).ToArray()
                };
            }
        }

        /// <summary>
        /// 日付文字列をDataTime型に変換します。
        /// </summary>
        /// <param name="datestr">日付文字列</param>
        /// <returns>変換済みデータ</returns>
        private static DateTime stringToDateTime(string datestr)
        {
            char[] sep = new char[2];
            sep[0] = 'T';
            sep[1] = '+';
            string newdatestr = datestr.Split(sep)[0].Replace('-', '/');
            string newtimestr = datestr.Split(sep)[1];
            return Convert.ToDateTime(newdatestr + " " + newtimestr);
        }
    }
}
