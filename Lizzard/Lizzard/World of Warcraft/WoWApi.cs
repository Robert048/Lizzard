using System;
using System.Net.Http;
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
                    var uri = new Uri("https://eu.api.battle.net/wow/" + apiLink + "locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
                    var response = await client.GetAsync(uri);
                    result = await response.Content.ReadAsStringAsync();
                }
                return result;
            }
    }
}