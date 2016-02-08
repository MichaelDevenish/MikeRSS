using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeRSS_V2
{
    class RSSFeed
    {
        private string name;
        private string url;

        public string Name { get { return name; } set { name = value; } }
        public string URL { get { return url; } set { url = value; } }

        public RSSFeed()
        {
        }
    }
}
