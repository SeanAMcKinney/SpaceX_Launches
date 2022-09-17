using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceX_Launches.ViewModels
{
    public class LaunchpadInfo
    {
        public string name { get; set; }
        public string full_name { get; set; }
        public string locality { get; set; }
        public string region { get; set; }
        public int launch_attempts { get; set; }
        public int launch_successes { get; set; }
        public string[] rockets { get; set; }
        public string timezone { get; set; }
        public string details { get; set; }
    }
}