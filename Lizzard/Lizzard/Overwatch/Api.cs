using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lizzard
{
    class Api
    {
        public async Task<string> get(string apiLink)
        {
            DataProfile data = new DataProfile(); ;
            var result = "";
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://api.lootbox.eu/" + apiLink);
                var response = await client.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
