using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        User user;
        public string charName;

        public MainPage()
        {
            this.InitializeComponent();
            user = new User { tag = "RedZerg-1884", region = "eu", platform = "pc" };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter == null)
            {

            }
            else
            {
                loadProfileData();
                charName = e.Parameter.ToString();
            }
        }

        private void profileBtn_Copy3_Click(System.Object sender, RoutedEventArgs e)
        {

        }

        private void profileBtn_Copy1_Click(System.Object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void loadProfileData()
        {
            if (charName != "")
            {
                WoWApi call = new WoWApi();
                var result = await call.get("character/Outland" + "/" + charName + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
                var jsonresult = JsonConvert.DeserializeObject<CharacterInformation>(result);
                image.Source = new BitmapImage(new Uri("http://render-api-eu.worldofwarcraft.com/static-render/eu/" + jsonresult.thumbnail));
                txtCharacter.Text =
                    jsonresult.name + Environment.NewLine +
                    "Level: " + jsonresult.level.ToString() + Environment.NewLine +
                    "Achievement points: " + jsonresult.achievementPoints.ToString();
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SetPage));

        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Profile), charName);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Guild));

        }
    }
}
