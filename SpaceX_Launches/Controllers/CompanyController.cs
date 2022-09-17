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
    public class CompanyController : Controller
    {
        // GET: Company
        public async Task<ActionResult> Index()
        {
            // Get JSON for history, return list of lhistory
            List<CompanyInfo> companyInformation = new List<CompanyInfo>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.spacexdata.com/v4/");
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.GetAsync("company");

                if (response.IsSuccessStatusCode)
                {
                    var companyResponse = response.Content.ReadAsStringAsync().Result;

                    companyInformation = JsonConvert.DeserializeObject<List<CompanyInfo>>(companyResponse);
                }
            }
            return View(companyInformation);
        }
    }
}