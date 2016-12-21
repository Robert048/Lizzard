using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// Heroes of the Storm page with all the map names of the game
    /// </summary>
    public sealed partial class MapsPage : Page
    {
        public MapsPage()
        {
            this.InitializeComponent();
            getMaps();
        }

        private async void getMaps()
        {
            Api call = new Api();
            var result = await call.get("Data/Maps");
            var jsonresult = JsonConvert.DeserializeObject<List<Map>>(result);
            foreach (var map in jsonresult)
            {
                listMaps.Items.Add(map.PrimaryName);
            }
            progressRing.IsActive = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
