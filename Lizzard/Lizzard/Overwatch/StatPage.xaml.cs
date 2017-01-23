using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Lizzard.Overwatch
{
    /// <summary>
    /// Overwatch profile statistics page
    /// </summary>
    public sealed partial class StatPage : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public StatPage()
        {
            this.InitializeComponent();
        }

        private async void getAchievements()
        {
            Api call = new Api();
            User user = new User();
            var tag = localSettings.Values["tag"];
            if (tag != null)
            {
                user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"], platform = (string)localSettings.Values["platform"] };
            }
            else
            {
                Frame.Navigate(typeof(LogInpage));
            }
            var result = await call.get(user.platform + "/" + user.region + "/" + user.tag + "/achievements");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectAchievements>(result);
            txtAchievements.Text = jsonresult.finishedAchievements + " completed"; ;
            progressRing.IsActive = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataProfile data = (DataProfile)e.Parameter;
            txtQuickPlay.Text = data.games.quick.wins + " Wins" + Environment.NewLine + data.playtime.quick + " playtime";
            if (data.competitive.rank != null)
            {
                txtCompetitive.Text = data.games.competitive.wins + " wins" + Environment.NewLine + data.playtime.competitive + " playtime" + Environment.NewLine + "Rank: " + data.competitive.rank;
            }
            else
            {
                txtCompetitive.Text = data.games.competitive.wins + " wins" + Environment.NewLine + data.playtime.competitive + " playtime";
            }
            image.Source = new BitmapImage(new Uri(data.avatar, UriKind.Absolute));
            txtData.Text = data.username + Environment.NewLine + "Level: " + data.level;

            getAchievements();
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
