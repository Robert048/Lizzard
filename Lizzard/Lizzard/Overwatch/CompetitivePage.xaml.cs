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
    /// Overwatch page to display the hero information on competitive games.
    /// </summary>
    public sealed partial class CompetitivePage : Page
    {
        private User user;
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public CompetitivePage()
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
            var result = await call.get(user.platform + "/" + user.region + "/" + user.tag + "/competitive/heroes");
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
            var result2 = await call2.get(user.platform + "/" + user.region + "/" + user.tag + "/competitive/hero/" + names + "/");
            var jsonresult2 = JsonConvert.DeserializeObject<dynamic>(result2);

            foreach (Hero hero in jsonresult)
            {
                if (hero.name == "D.Va")
                {
                    try
                    {
                        hero.eliminations = jsonresult2["DVa"]["Eliminations"];
                    }
                    catch (Exception) { }
                }
                else if (hero.name == "Lúcio")
                {
                    try
                    {
                        hero.eliminations = jsonresult2["Lucio"]["Eliminations"];
                    }
                    catch (Exception) { }
                }
                else if (hero.name == "Soldier: 76")
                {
                    try
                    {
                        hero.eliminations = jsonresult2["Soldier76"]["Eliminations"];
                    }
                    catch (Exception) { }
                }
                else if (hero.name == "McCree")
                {
                    try
                    {
                        hero.eliminations = jsonresult2["Mccree"]["Eliminations"];
                    }
                    catch (Exception) { }
                }
                else if (hero.name == "Torbjörn")
                {
                    try
                    {
                        hero.eliminations = jsonresult2["Torbjoern"]["Eliminations"];
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        hero.eliminations = jsonresult2[hero.name]["Eliminations"];
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
                gridView.Items.Add(hero);
            }
            progressRing.IsActive = false;
        }

        private void grid_SizeChanged(object sender, SizeChangedEventArgs e)
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