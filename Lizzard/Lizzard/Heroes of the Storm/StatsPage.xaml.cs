using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// Heroes of the Storm stat page
    /// </summary>
    public sealed partial class StatsPage : Page
    {
        private User user;
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public StatsPage()
        {
            this.InitializeComponent();
        }

        private async void getStats()
        {
            Api call = new Api();
            string region = "";
            string tag = "";
            switch (user.region)
            {
                case "us":
                    region = "1";
                    break;
                case "eu":
                    region = "2";
                    break;
                case "kr":
                    region = "3";
                    break;
                case "cn":
                    region = "4";
                    break;
                default:
                    region = "1";
                    break;
            }
            if (user.tag.Contains("-"))
            {
                tag = user.tag.Replace("-", "_");
            }
            var result = await call.get("Players/" + region + "/" + tag);
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var tag = localSettings.Values["tag"];
            if (tag != null)
            {
                this.user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"], platform = (string)localSettings.Values["platform"] };
            }
            else
            {
                Frame.Navigate(typeof(LogInpage));
            }
            getStats();
        }
    }
}
