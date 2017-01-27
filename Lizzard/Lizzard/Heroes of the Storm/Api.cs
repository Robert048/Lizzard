using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lizzard.Heroes_of_the_Storm
{
    class Api
    {
        //API call for the HotsLog API
        public async Task<string> getApi(string apiLink)
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

        //New URL for a part of the HotSLog API
        public async Task<string> getData(string apiLink)
        {
            var result = "";
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://www.hotslogs.com/API/" + apiLink);
                var response = await client.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
