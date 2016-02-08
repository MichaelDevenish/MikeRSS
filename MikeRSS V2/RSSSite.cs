using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikeRSS_V2
{
    class RSSSite
    {
        private string number;
        private string title;
        private string  url;

        public string Number { get {return number; } set {number = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string URL { get { return url; } set { url = value; } }
    }
}
