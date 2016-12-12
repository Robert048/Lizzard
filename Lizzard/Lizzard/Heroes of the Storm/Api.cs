using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lizzard.Heroes_of_the_Storm
{
    class Api
    {
        public async Task<string> get(string apiLink)
        {
            var result = "";
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://api.hotslogs.com/Public/" + apiLink);
                var response = await client.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
