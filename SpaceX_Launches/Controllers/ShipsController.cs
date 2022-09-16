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
    public class ShipsController : Controller
    {
        // GET: Ships

        // GET: History
        public async Task<ActionResult> Index()
        {
            // Get JSON for history, return list of lhistory
            List<ShipDetails> shipInfo = new List<ShipDetails>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.spacexdata.com/v4/");
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.GetAsync("ships");

                if (response.IsSuccessStatusCode)
                {
                    var shipResponse = response.Content.ReadAsStringAsync().Result;

                    shipInfo = JsonConvert.DeserializeObject<List<ShipDetails>>(shipResponse);
                }
            }
            return View(shipInfo);
        }
    }
}