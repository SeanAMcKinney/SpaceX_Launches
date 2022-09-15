using Newtonsoft.Json;
using SpaceX_Launches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpaceX_Launches.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public async Task<ActionResult> Index()
        {
            // Get JSON for history, return list of lhistory
            List<History> historyInfo = new List<History>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.spacexdata.com/v4/");
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.GetAsync("history");

                if (response.IsSuccessStatusCode)
                {
                    var historyResponse = response.Content.ReadAsStringAsync().Result;

                    historyInfo = JsonConvert.DeserializeObject<List<History>>(historyResponse);
                }
            }
            return View(historyInfo);
        }
    }