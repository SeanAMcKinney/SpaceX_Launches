using Newtonsoft.Json;
using SpaceX_Launches.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpaceX_Launches.Controllers
{
    public class LaunchpadsController : Controller
    {
        // GET: Launchpads
        public async Task<ActionResult> Index()
        {
            // Get JSON for history, return list of lhistory
            List<LaunchpadInfo> launchpadInformation = new List<LaunchpadInfo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.spacexdata.com/v4/");
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.GetAsync("launchpads");

                if (response.IsSuccessStatusCode)
                {
                    var launchpadResponse = response.Content.ReadAsStringAsync().Result;

                    launchpadInformation = JsonConvert.DeserializeObject<List<LaunchpadInfo>>(launchpadResponse);
                }
            }
            return View(launchpadInformation);
        }
    }
}