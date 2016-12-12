using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lizzard.Overwatch
{
    class Api
    {
        public async Task<string> get(string apiLink)
        {
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
