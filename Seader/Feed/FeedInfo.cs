using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seader.Feed
{
    /// <summary>
    /// フィードを表します。
    /// </summary>
    public class FeedInfo
    {
        private string title;
        private string description;
        private Uri url;
        private FeedItem[] items;

        public string Title
        {
            set { this.title = value; }
            get { return this.title; }
        }
        public string Description
        {
            set { this.description = value; }
            get { return this.description; }
        }
        public Uri Url
        {
            set { this.url = value; }
            get { return this.url; }
        }
        public FeedItem[] Items
        {
            set { this.items = value; }
            get { return this.items; }
        }
    }
}
