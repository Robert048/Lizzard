using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.Starcraft_2
{
    class SC2Api
    {
        public async Task<string> get(string apiLink)
        {
            var result = "";
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://eu.api.battle.net/sc2/" + apiLink);
                var response = await client.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
