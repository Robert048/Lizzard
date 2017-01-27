using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Lizzard.Overwatch
{
    /// <summary>
    /// Overwatch page to display the hero information on QuickPlay games.
    /// </summary>
    public sealed partial class QuickPlayPage : Page
    {
        private User user;
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public QuickPlayPage()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataProfile data = (DataProfile)e.Parameter;
            //check if usertag already exists
            var tag = localSettings.Values["tag"];
            if (tag != null)
            {
                this.user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"], platform = (string)localSettings.Values["platform"] };
            }
            //if no user exists then send to login page
            else
            {
                Frame.Navigate(typeof(LogInpage));
            }
            image.Source = new BitmapImage(new Uri(data.avatar, UriKind.Absolute));
            txtData.Text = data.username + Environment.NewLine + "Level: " + data.level;
            getheroes();
        }

        /// <summary>
        /// Gets Hero stats from API
        /// </summary>
        private async void getheroes()
        {
            //first call to get all the heroes and basic stats
            Api call = new Api();
            var result = await call.get(user.platform + "/" + user.region + "/" + user.tag + "/quickplay/heroes");
            var jsonresult = JsonConvert.DeserializeObject<List<Hero>>(result);
            string names = "";
            foreach (Hero hero in jsonresult)
            {
                if (hero.name == "D.Va")
                {
                    names = names + "DVa,";
                }
                else if (hero.name == "L&#xFA;cio")
                {
                    names = names + "Lucio,";
                    hero.name = "Lúcio";
                }
                else if (hero.name == "Soldier: 76")
                {
                    names = names + "Soldier76,";
                }
                else if (hero.name == "McCree")
                {
                    names = names + "Mccree,";
                }
                else if (hero.name == "Torbj&#xF6;rn")
                {
                    names = names + "Torbjoern,";
                    hero.name = "Torbjörn";
                }
                else
                {
                    names = names + hero.name + ",";
                }
            }
            names = names.Remove(names.Length - 1);

            //second call to get more information per hero
            Api call2 = new Api();
            var result2 = await call2.get(user.platform + "/" + user.region + "/" + user.tag + "/quickplay/hero/" + names + "/");
            var jsonresult2 = JsonConvert.DeserializeObject<dynamic>(result2);

            foreach (Hero hero in jsonresult)
            {
                if (hero.name == "D.Va")
                {
                    hero.eliminations = jsonresult2["DVa"]["Eliminations-Average"];
                    hero.damage = jsonresult2["DVa"]["DamageDone-Average"];
                    double kills = jsonresult2["DVa"]["Eliminations"];
                    double deaths = jsonresult2["DVa"]["Deaths"];
                    hero.kdratio = kills / deaths;
                    hero.accuracy = jsonresult2["DVa"]["WeaponAccuracy"];
                    hero.objTime = jsonresult2["DVa"]["ObjectiveTime-Average"];
                }
                else if (hero.name == "Lúcio")
                {
                    hero.eliminations = jsonresult2["Lucio"]["Eliminations-Average"];
                    hero.damage = jsonresult2["Lucio"]["DamageDone-Average"];
                    double kills = jsonresult2["Lucio"]["Eliminations"];
                    double deaths = jsonresult2["Lucio"]["Deaths"];
                    hero.kdratio = kills / deaths;
                    hero.accuracy = jsonresult2["Lucio"]["WeaponAccuracy"];
                    hero.objTime = jsonresult2["Lucio"]["ObjectiveTime-Average"];
                }
                else if (hero.name == "Soldier: 76")
                {
                    hero.eliminations = jsonresult2["Soldier76"]["Eliminations-Average"];
                    hero.damage = jsonresult2["Soldier76"]["DamageDone-Average"];
                    double kills = jsonresult2["Soldier76"]["Eliminations"];
                    double deaths = jsonresult2["Soldier76"]["Deaths"];
                    hero.kdratio = kills / deaths;
                    hero.accuracy = jsonresult2["Soldier76"]["WeaponAccuracy"];
                    hero.objTime = jsonresult2["Soldier76"]["ObjectiveTime-Average"];
                }
                else if (hero.name == "McCree")
                {
                    hero.eliminations = jsonresult2["Mccree"]["Eliminations-Average"];
                    hero.damage = jsonresult2["Mccree"]["DamageDone-Average"];
                    double kills = jsonresult2["Mccree"]["Eliminations"];
                    double deaths = jsonresult2["Mccree"]["Deaths"];
                    hero.kdratio = kills / deaths;
                    hero.accuracy = jsonresult2["Mccree"]["WeaponAccuracy"];
                    hero.objTime = jsonresult2["Mccree"]["ObjectiveTime-Average"];
                }
                else if (hero.name == "Torbjörn")
                {
                    hero.eliminations = jsonresult2["Torbjoern"]["Eliminations-Average"];
                    hero.damage = jsonresult2["Torbjoern"]["DamageDone-Average"];
                    double kills = jsonresult2["Torbjoern"]["Eliminations"];
                    double deaths = jsonresult2["Torbjoern"]["Deaths"];
                    hero.kdratio = kills / deaths;
                    hero.accuracy = jsonresult2["Torbjoern"]["WeaponAccuracy"];
                    hero.objTime = jsonresult2["Torbjoern"]["ObjectiveTime-Average"];
                }
                else
                {
                    try
                    {
                        hero.eliminations = jsonresult2[hero.name]["Eliminations-Average"];
                        hero.damage = jsonresult2[hero.name]["DamageDone-Average"];
                        double kills = jsonresult2[hero.name]["Eliminations"];
                        double deaths = jsonresult2[hero.name]["Deaths"];
                        hero.kdratio = kills / deaths;
                        hero.accuracy = jsonresult2[hero.name]["WeaponAccuracy"];
                        hero.objTime = jsonresult2[hero.name]["ObjectiveTime-Average"];
                    }
                    catch(Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
                gridView.Items.Add(hero);
            }
            progressRing.IsActive = false;
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
