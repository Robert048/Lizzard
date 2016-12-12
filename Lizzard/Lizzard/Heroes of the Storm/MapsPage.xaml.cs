using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
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
                txtMaps.Text = txtMaps.Text + map.PrimaryName + Environment.NewLine;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
