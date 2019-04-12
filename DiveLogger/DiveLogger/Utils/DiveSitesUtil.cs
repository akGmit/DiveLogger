using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using DiveLogger.Models;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
/*
* Utilities class for DiveSitesViewModel.
* */
namespace DiveLogger.Utils
{
    public class DiveSitesUtil
    {
        private static HttpClient httpClient = new HttpClient();
        
        /// <summary>
        /// Sends get request to divesites.com and retrieves response in JSON format.
        /// </summary>
        /// <param name="lat">A double representing latitude coordinate.</param>
        /// <param name="lng">A double representing longitude coordinate.</param>
        /// <param name="dist">A double representing radius of visible area.</param>
        /// <returns>An ObservableCollection of DiveSiteModel objects.</returns>
        public static async Task<ObservableCollection<DiveSiteModel>> GetDiveSitesAsync(double lat, double lng, double dist)
        {
            var responseString = await  httpClient.GetStringAsync("http://www.divesites.com/rest/?{%22mode%22:%22sites%22,%22lat%22:" + lat + ",%22lng%22:" + lng + ",%22dist%22:" + dist + "}");
            JObject o = JObject.Parse(responseString);
            IList<JToken> s = o["sites"].Children().ToList();

            ObservableCollection<DiveSiteModel> sites = new ObservableCollection<DiveSiteModel>();
            foreach (JToken r in s)
            {
                DiveSiteModel diveSite = r.ToObject<DiveSiteModel>();
                sites.Add(diveSite);
            }
            return sites;
        }
    }
}
