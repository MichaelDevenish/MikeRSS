using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebsiteClass
{
    public class Website
    {
        //variables
        private XmlTextReader rssReader;
        private XmlDocument rssDoc;
        private XmlNode nodeRss;
        private XmlNode nodeChannel;

        //properties
        public XmlTextReader RssReader { get { return rssReader; } set { rssReader = value; } }
        public XmlDocument RssDoc { get { return rssDoc; } set { rssDoc = value; } }
        public XmlNode NodeRss { get { return nodeRss; } set { nodeRss = value; } }
        public XmlNode NodeChannel { get { return nodeChannel; } set { nodeChannel = value; } }

        //constructors
        public Website()
        {
            throw new ArgumentException("Must enter a website into the constructor");
        }
        public Website(string site)
        {
            rssReader = new XmlTextReader(site);
            rssDoc = new XmlDocument();

            rssDoc.Load(rssReader);
            convertToNodes();
        }

        //functions
        /// <summary>
        /// overrides the ToString function to return the baseURL
        /// </summary>
        /// <returns>the baseURL</returns>
        public override string ToString()
        {
            return NodeChannel.BaseURI;
        }

        /// <summary>
        /// gets the rss node and channel node from rssDoc
        /// </summary>
        private void convertToNodes()
        {
            for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
                if (rssDoc.ChildNodes[i].Name == "rss")
                    nodeRss = rssDoc.ChildNodes[i];

            for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
                if (nodeRss.ChildNodes[i].Name == "channel")
                    nodeChannel = nodeRss.ChildNodes[i];
        }
    }
}
