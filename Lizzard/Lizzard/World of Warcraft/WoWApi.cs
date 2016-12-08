using Lizzard.World_of_Warcraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Lizzard.World_of_Warcraft
{
    class WoWApi
    {
        
            public async Task<string> get(string apiLink)
            {
                var result = "";
                using (var client = new HttpClient())
                {
                    var uri = new Uri("https://eu.api.battle.net/wow/" + apiLink);
                    var response = await client.GetAsync(uri);
                    result = await response.Content.ReadAsStringAsync();
                }
                return result;
            }
    }
}