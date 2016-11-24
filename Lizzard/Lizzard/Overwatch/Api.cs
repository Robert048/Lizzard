using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lizzard
{
    class Api
    {
        public async Task<Data> get(string apiLink)
        {
            Data data = new Data(); ;
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = new Uri(apiLink);
                    var response = await client.GetAsync(uri);
                    var result = await response.Content.ReadAsStringAsync();
                    var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);
                    data = jsonresult.data;
                }
                catch (Exception ex)
                {

                }
            }
            return data;
        }
    }
}
