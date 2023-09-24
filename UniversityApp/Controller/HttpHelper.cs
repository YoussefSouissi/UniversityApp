using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace UniversityApp.Controller
{
    internal class HttpHelper
    {


        public async Task<String> GetResponseAsync(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else { return null; }
            }
        }
    }
}