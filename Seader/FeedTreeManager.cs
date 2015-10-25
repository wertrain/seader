using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing;

namespace Seader
{
    class FeedTreeManager
    {
        /// <summary>
        /// フィードのデータを持つノードです。
        /// </summary>
        public class FeedTreeNode : TreeNode
        {
            private string title;
            private string description;
            private string content;
            private string summary;
            private DateTime date;
            private Uri url;
            private bool read;
            private int iconIndex;

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
            public Uri Url
            {
                set { this.url = value; }
                get { return this.url; }
            }
            public bool Read
            {
                set { this.read = value; }
                get { return this.read; }
            }
            public int IconIndex
            {
                set { this.iconIndex = value; }
                get { return this.iconIndex; }
            }
        }

        private List<FeedTreeNode> parentNodeList;
        private Dictionary<FeedTreeNode, List<FeedTreeNode>> childNodeList;
        private Dictionary<string, int> faviconIndexList;
        private List<Bitmap> faviconList;

        public FeedTreeManager()
        {
            this.parentNodeList = new List<FeedTreeNode>();
            this.faviconIndexList = new Dictionary<string, int>();
            this.childNodeList = new Dictionary<FeedTreeNode, List<FeedTreeNode>>();
            this.faviconList = new List<Bitmap>();
        }

        /// <summary>
        /// URLからファビコンを取得し、イメージリストに保存します。
        /// 既に取得済みのファビコンだった場合は新たに取得せず、インデックスを返します。
        /// </summary>
        /// <param name="uri">ファビコンを取得するURL</param>
        /// <returns>イメージリスト上のインデックス</returns>
        private int GetFaviconIndex(Uri uri)
        {
            var index = 0;
            if (false == this.faviconIndexList.TryGetValue(uri.Host, out index))
            {
                Uri target = new Uri("http://www.google.com/s2/favicons?domain=" + uri.Host);
                using (WebClient webClient = new WebClient())
                using (MemoryStream stream = new MemoryStream(webClient.DownloadData(target)))
                {
                    var image = new Bitmap(stream);
                    this.faviconList.Add(image);
                    index = this.faviconList.Count - 1;
                    this.faviconIndexList[uri.Host] = index;
                }
            }
            return index;
        }

        /// <summary>
        /// フィードをツリーに追加、または既にあるノードを更新します。
        /// このメソッドは、バックグラウンドワーカーから呼び出されるため、UIの操作は避けています。
        /// </summary>
        /// <param name="feedInfo">追加、または更新するフィード</param>
        /// <returns></returns>
        public bool UpdateFeed(Feed.FeedInfo feedInfo)
        {
            if (null == feedInfo)
            {
                return false;
            }

            FeedTreeNode parentNode = null;

            foreach (var node in this.parentNodeList)
            {
                if (node.Url.ToString() == feedInfo.Url.ToString())
                {
                    parentNode = node;
                    break;
                }
            }

            if (null == parentNode)
            {
                parentNode = new FeedTreeNode();
                this.parentNodeList.Add(parentNode);
            }

            parentNode.Title = feedInfo.Title;
            parentNode.Description = feedInfo.Description;
            parentNode.Url = feedInfo.Url;
            parentNode.ToolTipText = feedInfo.Description;
            parentNode.IconIndex = GetFaviconIndex(feedInfo.Url);

            List<FeedTreeNode> childList;
            if (false == this.childNodeList.TryGetValue(parentNode, out childList))
            {
                this.childNodeList.Add(parentNode, new List<FeedTreeNode>());
            }

            foreach (var item in feedInfo.Items)
            {
                FeedTreeNode childNode = null;

                foreach (FeedTreeNode child in this.childNodeList[parentNode])
                {
                    if (child.Url.ToString() == item.Link.ToString())
                    {
                        childNode = child;
                        break;
                    }
                }

                if (null == childNode)
                {
                    childNode = new FeedTreeNode();
                    this.childNodeList[parentNode].Add(childNode);
                }

                childNode.Title = item.Title;
                childNode.Content = item.Content;
                childNode.Summary = item.Summary;
                childNode.Url = item.Link;
                childNode.Date = item.Date;
                childNode.IconIndex = GetFaviconIndex(item.Link);         
            }

            return true;
        }

        /// <summary>
        /// フィードを管理から削除します。
        /// </summary>
        /// <param name="node"></param>
        public void RemoveFeed(FeedTreeNode node)
        {
            this.parentNodeList.Remove(node);
        }

        /// <summary>
        /// フィード内のアイテムをすべて既読にします。
        /// </summary>
        /// <param name="node"></param>
        public void ReadAll(FeedTreeNode node)
        {
            foreach (FeedTreeNode child in node.Nodes)
            {
                child.Read = true;
            }
            node.Nodes.Clear();
        }
        
        /// <summary>
        /// 管理しているデータをツリービューに反映させます。
        /// </summary>
        /// <param name="treeView"></param>
        public void ReflectTreeView(ref TreeView treeView)
        {
            treeView.ImageList.Images.Clear();
            foreach (var image in this.faviconList)
            {
                treeView.ImageList.Images.Add(image);
            }
            foreach (FeedTreeNode node in this.parentNodeList)
            {
                // UpdateFeed では、UIまわりの変更を避けるため
                // （もし、UpdateFeedで TreeView に追加済みのノードを触った場合アクセスエラーになる）
                // ここで変更を反映させる
                node.Text = node.Title;
                node.ImageIndex = node.IconIndex;
                node.SelectedImageIndex = node.IconIndex;

                foreach (FeedTreeNode child in this.childNodeList[node])
                {
                    if (false == child.Read)
                    {
                        child.Text = child.Title;
                        child.ImageIndex = child.IconIndex;
                        child.SelectedImageIndex = child.IconIndex;
                        if (false == node.Nodes.Contains(child))
                        {
                            node.Nodes.Add(child);
                        }                        
                    }
                }
                if (false == treeView.Nodes.Contains(node))
                {
                    treeView.Nodes.Add(node);
                }
            }
        }
    }
}
