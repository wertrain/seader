using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Seader
{ 
    class SettingsManager
    {
        private Settings settings;
        private string settingsFilePath;

        public SettingsManager()
        {
            this.settings = new Settings();
            this.settingsFilePath = System.IO.Directory.GetCurrentDirectory() + "\\" + "settings.xml";
        }

        public bool Write()
        {
            try
            {
                XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(Settings) })[0];
                using (FileStream fs = new FileStream(this.settingsFilePath, FileMode.Create))
                {
                    serializer.Serialize(fs, this.settings);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Read()
        {
            try
            {
                XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(Settings) })[0];
                using (FileStream fs = new FileStream(this.settingsFilePath, FileMode.Open))
                {
                    this.settings = (Settings)serializer.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public string FilePath
        {
            get { return this.settingsFilePath; }
            set { this.settingsFilePath = value; }
        }

        public Settings Setting
        {
            get { return this.settings; }
        }
    }

    /// <summary>
    /// アプリの設定データです。
    /// </summary>
    public class Settings
    {
        private int splitterDistance;
        private Size formSize;
        private int feedsUpdateInterval;
        private Orientation orientation;

        [System.Xml.Serialization.XmlArrayItem(typeof(string))]
        private List<string> feedUrls;

        public Settings()
        {
            this.splitterDistance = 320;
            this.feedUrls = new List<string>();
            this.formSize = new Size(500, 600);
            this.feedsUpdateInterval = 30;
            this.orientation = Orientation.Horizontal;
        }

        public int SplitterDistance
        {
            get { return this.splitterDistance; }
            set { this.splitterDistance = value; }
        }

        public Size FormSize
        {
            get { return this.formSize; }
            set { this.formSize = value; }
        }

        public List<string> FeedUrls
        {
            get { return this.feedUrls; }
        }

        public int FeedsUpdateInterval
        {
            get { return this.feedsUpdateInterval; }
            set { this.feedsUpdateInterval = value; }
        }

        public Orientation Orientation
        {
            get { return this.orientation; }
            set { this.orientation = value; }
        }
    }
}
