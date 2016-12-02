using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.Overwatch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverwatchSubPage : Page
    {
        private User user;
        public OverwatchSubPage()
        {
            this.InitializeComponent();
        }

        private async void getAchievements()
        {
            Api call = new Api();
            var result = await call.get(user.platform + "/" + user.region + "/" + user.tag + "/achievements");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectAchievements>(result);
            txtAchievements.Text = jsonresult.finishedAchievements + " completed"; ;
            progressRing.IsActive = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OverwatchMainPage), user);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Dictionary<string, object> parameters = (Dictionary<string, object>)e.Parameter;
            DataProfile data = (DataProfile)parameters["data"];
            User user = (User)parameters["user"];
            this.user = user;
            txtQuickPlay.Text = data.games.quick.wins + " Wins" + Environment.NewLine + data.playtime.quick + " Hours playtime";
            if (data.competitive.rank != null)
            txtCompetitive.Text = data.games.competitive.wins + " wins" + Environment.NewLine + data.playtime.competitive + " playtime" + Environment.NewLine + "Rank: " + data.competitive.rank;
            txtCompetitive.Text = data.games.competitive.wins + " wins" + Environment.NewLine + data.playtime.competitive + " playtime";
            image.Source = new BitmapImage(new Uri(data.avatar, UriKind.Absolute));
            txtData.Text = data.username + System.Environment.NewLine + "Level: " + data.level;

            getAchievements();
        }
    }
}
