using Newtonsoft.Json;
using SpaceX_Launch_Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaceX_Launch_Website.Controllers
{
    public class LaunchesController : Controller
    {
        // GET: Launches
        public async Task<ActionResult> Index()
        {
            // Get JSON for launches, return list of launches
            List<Launches> launchInfo = new List<Launches>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.spacexdata.com/v5/");
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.GetAsync("launches");

                if (response.IsSuccessStatusCode)
                {
                    var launchResponse = response.Content.ReadAsStringAsync().Result;

                    launchInfo = JsonConvert.DeserializeObject<List<Launches>>(launchResponse);
                }
            }

            // Get JSON for payloads, return list of payloads
            List<Payloads> payloadInfo = new List<Payloads>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.spacexdata.com/v4/");
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage response = await client.GetAsync("payloads");

                if (response.IsSuccessStatusCode)
                {
                    var payloadResponse = response.Content.ReadAsStringAsync().Result;

                    payloadInfo = JsonConvert.DeserializeObject<List<Payloads>>(payloadResponse);
                }
            }
            // Take payloads and transform into PayloadMass object that holds launch id and weight
            var payloads = payloadInfo.Select(x => new PayloadMass { Launch = x.launch, MassLbs = x.mass_lbs });

            // join launch info with payloads on id.  Assign properties to LaunchWithPayload POCO
            var launchWithMass = from l in launchInfo
                                 join p in payloads
                                    on l.id equals p.Launch
                                 select new LaunchWithPayload
                                 {
                                     Name = l.name,
                                     DateLocal = l.date_local,
                                     Success = l.success,
                                     MassLbs = p.MassLbs
                                 };

            // Order a new list by mass.
            var orderByMass = launchWithMass.OrderByDescending(x => x.MassLbs).ToList();

            // Iterate through orderByMass list using the index to assign rank unless null.  Null gets assigned 0.
            for (int i = 0; i < orderByMass.Count(); i++)
            {
                if (orderByMass[i].MassLbs == null)
                {
                    orderByMass[i].Rank = 0;
                }
                else
                {
                    orderByMass[i].Rank = i;
                }
            }

            // Order by date
            var launches = orderByMass.OrderByDescending(x => x.DateLocal);

            return View(launches);
        }
    }
}