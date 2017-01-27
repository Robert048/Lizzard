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
            updateCards();
        }

        /// <summary>
        /// update the card file in localstorage
        /// </summary>
        private async void updateCards()
        {
            var result = await get();
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);

            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var textFile = await folder.CreateFileAsync("cards.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(textFile, result);

            progressRing.IsActive = false;
            btnReload.IsEnabled = true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }

        /// <summary>
        /// gets cards from API
        /// </summary>
        /// <returns>result string</returns>
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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateDeckPage));
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            btnReload.IsEnabled = false;
            updateCards();
        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManageDeckPage));
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (grid != null)
            {
                if (grid.ActualHeight > grid.ActualWidth)
                {
                    VisualStateManager.GoToState(this, "Phone", false);
                }
                else if (grid.ActualWidth < 1024)
                {
                    VisualStateManager.GoToState(this, "Tablet", false);
                }
                else
                {
                    VisualStateManager.GoToState(this, "Standard", false);
                }
            }
        }
    }
}
