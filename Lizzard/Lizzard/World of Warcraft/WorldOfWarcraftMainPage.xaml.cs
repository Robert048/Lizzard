using Lizzard.World_of_Warcraft;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorldOfWarcraftMainPage : Page
    {
        User user;
        public string charName;

        public WorldOfWarcraftMainPage()
        {
            this.InitializeComponent();
            user = new User { tag = "RedZerg-1884", region = "eu", platform = "pc" };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadProfileData();
            base.OnNavigatedTo(e);
            if (e.Parameter == null)
            {

            }
            else
            {
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
            WoWApi call = new WoWApi();
            var result = await call.get("Outland" + "/" + "Nuclaer" + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<CharacterInformation>(result);
            image.Source = new BitmapImage(new Uri("http://render-api-eu.worldofwarcraft.com/static-render/eu/outland/217/137868505-avatar.jpg"));
            txtCharacter.Text =
                jsonresult.name + Environment.NewLine +
                "Level: " + jsonresult.level.ToString() + Environment.NewLine +
                "Achievement points: " + jsonresult.achievementPoints.ToString();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WoWSetPage));

        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WoWProfile), charName);
        }
    }
}
