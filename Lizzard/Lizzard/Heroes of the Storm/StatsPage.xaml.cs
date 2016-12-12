using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StatsPage : Page
    {
        public StatsPage()
        {
            this.InitializeComponent();
            getStats();
        }

        private async void getStats()
        {
            Api call = new Api();
            var result = await call.get("Players/2/Mandela_2595");
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);
            txtStats.Text = txtStats.Text + jsonresult.Name + Environment.NewLine;
            foreach (var rank in jsonresult.LeaderboardRankings)
            {
                txtStats.Text = txtStats.Text + rank.GameMode + rank.LeagueRank + Environment.NewLine;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
