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
            //get region and tag from localstorage and set it in correct format for this API
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
            //get player stats
            var result = await call.getApi("Players/" + region + "/" + tag);
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);
            if (jsonresult != null)
            {
                txtStats.Text = "Name: " + jsonresult.Name + Environment.NewLine + "Player ID: " + jsonresult.PlayerID;
                foreach (var rank in jsonresult.LeaderboardRankings)
                {
                    txtLeaderboard1.Text = txtLeaderboard1.Text + "Gamemode: " + rank.GameMode + Environment.NewLine;
                    txtLeaderboard3.Text = txtLeaderboard3.Text + "Current MMR: " + rank.CurrentMMR + Environment.NewLine;
                    if (rank.LeagueRank != null)
                    {
                        txtLeaderboard2.Text = txtLeaderboard2.Text + "Rank: " + rank.LeagueRank + Environment.NewLine;
                    }
                    else
                    {
                        txtLeaderboard2.Text = txtLeaderboard2.Text + "Rank: Not ranked" + Environment.NewLine;
                    }
                }
            }
            else
            {
                string username = "";
                if (user.tag.Contains("-"))
                {
                    username = user.tag.Replace("-", "#");
                }
                else if (user.tag.Contains("_"))
                {
                    username = user.tag.Replace("_", "#");
                }
                txtStats.Text = "This Battletag and region combination does not exist in Heroes of the Storm." + Environment.NewLine + "Battletag: " + username + Environment.NewLine + "Region: " + user.region;
            }
            progressRing.IsActive = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //get user info if logged in
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
