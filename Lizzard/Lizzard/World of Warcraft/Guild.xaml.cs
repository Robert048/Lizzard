using Newtonsoft.Json;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Guild : Page
    {

        public Guild()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadGuildInformation();
        }

        private async void loadGuildInformation()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("guild/Outland/" + "%20Sky?fields=achievements%2Cchallenge&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectGuild>(result);
            txtGuildInformation.Text =
                "Name: " + jsonresult.name.ToString() + Environment.NewLine + //wtf?
               "Level: " + jsonresult.level.ToString() + Environment.NewLine +
               "Achievement points: " + jsonresult.achievementPoints.ToString();

        }


        private void btnBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
