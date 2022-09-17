using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceX_Launches.ViewModels
{
    public class CompanyInfo
    {
        public Headquarters headquarters { get; set; }
        public Links links { get; set; }
        public string name { get; set; }
        public string founder { get; set; }
        public int founded { get; set; }
        public int vehicles { get; set; }
        public int launch_sites { get; set; }
        public int test_sites { get; set; }
        public string summary { get; set; }
    }
}