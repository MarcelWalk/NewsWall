using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace NewsWall.Models
{
    public class FeedViewModel
    {
        public IEnumerable<SyndicationItem> Feeds { get; set; }

        public FeedViewModel(string v)
        {
            Feeds = GetFeeds(v);
        }

        public IEnumerable<SyndicationItem> GetFeeds(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            return feed.Items;
        }
    }
}
