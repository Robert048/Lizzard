using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard.Hearthstone
{
    /// <summary>
    /// Hearthstone mainpage
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            test();
            
        }

        private async void test()
        {
            var result = await get();
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);
            progressRing.IsActive = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }

        public async Task<string> get()
        {
            RootObject data = new RootObject(); ;
            var result = "";
            using (var client = new HttpClient())
            {
                var uri = new Uri("https://omgvamp-hearthstone-v1.p.mashape.com/cards");
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "cSPzfDcKVfmsh4kiB4XHkgg5E1dFp14bMLEjsnG1hwmoM99Mjk");
                var response = await client.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
