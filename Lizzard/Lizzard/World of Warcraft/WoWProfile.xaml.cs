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
    public sealed partial class WoWProfile : Page
    {
        public WoWProfile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            loadProfileData();
            loadIconProfileData();
            loadActivity();
            loadStats();

        }

        private async void loadProfileData()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("Outland" + "/" + "Nuclaer"+ "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
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
            var result = await call.get("Outland" + "/" + "Nuclaer" + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
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
            var result = await call.get("Outland/Nuclaer?fields=feed&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectFeed>(result);
            txtActivity.Text =
                jsonresult.feed[0].type.ToString() + Environment.NewLine;
        }

        private async void loadStats()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("Outland/Nuclaer?fields=stats&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
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
    }
}
