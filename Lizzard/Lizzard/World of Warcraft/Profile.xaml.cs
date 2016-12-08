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
    public sealed partial class Profile : Page
    {
        private string charName;

        public Profile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                charName = e.Parameter.ToString();
                loadProfileData();
                loadIconProfileData();
                loadActivity();
                loadStats();
                loadItems();
            }
            catch
            {
                showError();
          
            }


        }

        private async void showError()
        {
            var message = new MessageDialog("Please insert a character name.");
            await message.ShowAsync();
            Frame.Navigate(typeof(SetPage));
        }


        private async void loadProfileData()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/Outland" + "/" + charName + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<CharacterInformation>(result);
            txtProfile.Text =
                "Name: " + jsonresult.name + Environment.NewLine +
                "Level: " + jsonresult.level.ToString() + Environment.NewLine +
                "Achievement points: " + jsonresult.achievementPoints.ToString() + Environment.NewLine +
                "Total Honorable Kills: " + jsonresult.totalHonorableKills.ToString() + Environment.NewLine +
                "Realm: " + jsonresult.realm.ToString();
                
        }

        private async void loadIconProfileData()
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

        private async void loadActivity()
        {
           
            WoWApi call = new WoWApi();
            var result = await call.get("character/Outland/" + charName + "?fields=feed&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectFeed>(result);
            txtActivity.Text =
                jsonresult.feed[0].type.ToString() + Environment.NewLine;
        }

        private async void loadStats()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/Outland/" + charName + "?fields=stats&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectStats>(result);
            txtStats.Text =
                "Health: " + jsonresult.stats.health.ToString() + Environment.NewLine +
                "Mana: " + jsonresult.stats.power.ToString() + Environment.NewLine +
                "Strength: " + jsonresult.stats.str.ToString() + Environment.NewLine +
                "Agility: " + jsonresult.stats.agi.ToString() + Environment.NewLine +
                "Intellect: " + jsonresult.stats.@int.ToString() + Environment.NewLine +
                "Stamina: " + jsonresult.stats.sta.ToString() + Environment.NewLine +
                "Critical rating: " + jsonresult.stats.crit.ToString() + Environment.NewLine +
                "Haste rating: " + jsonresult.stats.haste.ToString() + Environment.NewLine;
        }

        private async void loadItems()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/Outland/" + charName + "?fields=items&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectItems>(result);
            txtItems.Text =
                "Equipped item level: " + jsonresult.items.averageItemLevelEquipped.ToString() + Environment.NewLine +
                "Item level: " + jsonresult.items.averageItemLevel.ToString() + Environment.NewLine +
                "Chest: " + jsonresult.items.chest.name.ToString() + Environment.NewLine +
                "Back: " + jsonresult.items.back.name.ToString() + Environment.NewLine +
                "Feet: " + jsonresult.items.feet.name.ToString() + Environment.NewLine +
                "Mainhand: " + jsonresult.items.mainHand.name.ToString() + Environment.NewLine +
                "Neck: " + jsonresult.items.neck.name.ToString() + Environment.NewLine;

        }

        private void btnBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
