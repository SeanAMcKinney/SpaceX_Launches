using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceX_Launches.ViewModels
{
    public class ShipDetails
    {
        public string legacy_id { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public string[] roles { get; set; }
        public int? _class { get; set; }
        public int? mass_kg { get; set; }
        public int? mass_lbs { get; set; }
        public int? year_built { get; set; }
        public string home_port { get; set; }
        public string status { get; set; }
        public object speed_kn { get; set; }
        public string link { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string[] launches { get; set; }
        public string id { get; set; }
    }
}