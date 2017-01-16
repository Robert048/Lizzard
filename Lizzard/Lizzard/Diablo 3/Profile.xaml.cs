﻿using Newtonsoft.Json;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lizzard.Diablo_3
{
    /// <summary>
    /// Diablo 3 profile page
    /// </summary>
    public sealed partial class Profile : Page
    {

        private User user;
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public Profile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadMembers();
            loadCareerInformation();
        }

        private async void loadCareerInformation()
        {
            Api call = new Api();

            var tag = localSettings.Values["tag"];
            user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"]};
            var result = await call.get("/profile/" + user.tag + "/?locale=" + user.region + "&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);
            if (jsonresult.battleTag != null)
            {
                ringInfo.IsActive = false;
                txtCareerInfo.Text =
                    "BattleTag: " + jsonresult.battleTag + Environment.NewLine +
                    "Paragon level: " + jsonresult.paragonLevel + Environment.NewLine +
                    "Guild: " + jsonresult.guildName + Environment.NewLine +
                    "Amount of heroes: " + jsonresult.heroes.Count.ToString() + Environment.NewLine + Environment.NewLine +
                    "Total monster kills: " + jsonresult.kills.monsters.ToString() + Environment.NewLine +
                    "Total elite kills: " + jsonresult.kills.elites.ToString() + Environment.NewLine +
                    "Total hardcore monster kills: " + jsonresult.kills.hardcoreMonsters.ToString() + Environment.NewLine + Environment.NewLine +
                    "Season 6 paragon level: " + jsonresult.seasonalProfiles.season5.paragonLevel.ToString() + Environment.NewLine +
                    "Season 5 paragon level: " + jsonresult.seasonalProfiles.season4.paragonLevel.ToString() + Environment.NewLine +
                    "Season 4 paragon level: " + jsonresult.seasonalProfiles.season3.paragonLevel.ToString() + Environment.NewLine +
                    "Season 3 paragon level: " + jsonresult.seasonalProfiles.season2.paragonLevel.ToString() + Environment.NewLine +
                    "Season 2 paragon level: " + jsonresult.seasonalProfiles.season1.paragonLevel.ToString() + Environment.NewLine +
                    "Season 1 paragon level: " + jsonresult.seasonalProfiles.season0.paragonLevel.ToString() + Environment.NewLine;
            }
            if (jsonresult.battleTag == null)
            {
                var dialog = new MessageDialog("You do not own this game.");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }
            

        private async void loadMembers()
        {
            Api call = new Api();
            var tag = localSettings.Values["tag"];
            user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"] };
            var result = await call.get("/profile/" + user.tag + "/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);
            if (jsonresult.battleTag != null)
            {
                ringCharacters.IsActive = false;
                foreach (Hero h in jsonresult.heroes)
                {
                    string name = h.@class.Replace("-", "");
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/" + name + "_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/" + name + "_female.png";
                    }
                    gridView.Items.Add(h);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}