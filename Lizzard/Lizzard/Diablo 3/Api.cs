using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lizzard.Diablo_3
{
    class Api
    {
        public async Task<string> get(string apiLink)
        {
            var result = "";
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://eu.api.battle.net/d3/" + apiLink);
                var response = await client.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
