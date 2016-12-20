using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Presentation.Models
{
    public class RestUsers
    {

        readonly string uri = "http://localhost:51020/api/Values";

        public async Task<List<Person>> GetUsersAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {

                return JsonConvert.DeserializeObject<List<Person>>(
                    await httpClient.GetStringAsync(uri)
                );
            }
        }
    }
}