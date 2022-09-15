using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceX_Launches.Models
{
    public class History
    {
        public Links links { get; set; }
        public string title { get; set; }
        public DateTime event_date_utc { get; set; }
        public int event_date_unix { get; set; }
        public string details { get; set; }
        public string id { get; set; }
    }
}