using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seader.Feed
{
    /// <summary>
    /// フィード内の1件の記事を表します。
    /// </summary>
    public class FeedItem
    {
        private string title;
        private string content;
        private string summary;
        private DateTime date;
        private Uri link;

        public string Title
        {
            set { this.title = value; }
            get { return this.title; }
        }
        public string Content
        {
            set { this.content = value; }
            get { return this.content; }
        }
        public string Summary
        {
            set { this.summary = value; }
            get { return this.summary; }
        }
        public DateTime Date
        {
            set { this.date = value; }
            get { return this.date; }
        }
        public Uri Link
        {
            set { this.link = value; }
            get { return this.link; }
        }
    }
}
