﻿using Newtonsoft.Json;
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
    public sealed partial class QuickPlayPage : Page
    {
        User user;
        public QuickPlayPage()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), user);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Dictionary<string, object> parameters = (Dictionary<string, object>)e.Parameter;
            DataProfile data = (DataProfile)parameters["data"];
            User user = (User)parameters["user"];
            this.user = user;
            image.Source = new BitmapImage(new Uri(data.avatar, UriKind.Absolute));
            txtData.Text = data.username + System.Environment.NewLine + "Level: " + data.level;
            getheroes();
        }

        private async void getheroes()
        {
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
            Api call2 = new Api();
            var result2 = await call2.get(user.platform + "/" + user.region + "/" + user.tag + "/quickplay/hero/" + names + "/");
            var jsonresult2 = JsonConvert.DeserializeObject<dynamic>(result2);

            foreach (Hero hero in jsonresult)
            {
                if (hero.name == "D.Va")
                {
                    hero.eliminations = jsonresult2["DVa"]["Eliminations"];
                }
                else if (hero.name == "Lúcio")
                {
                    hero.eliminations = jsonresult2["Lucio"]["Eliminations"];
                }
                else if (hero.name == "Soldier: 76")
                {
                    hero.eliminations = jsonresult2["Soldier76"]["Eliminations"];
                }
                else if (hero.name == "McCree")
                {
                    hero.eliminations = jsonresult2["Mccree"]["Eliminations"];
                }
                else if (hero.name == "Torbjörn")
                {
                    hero.eliminations = jsonresult2["Torbjoern"]["Eliminations"];
                }
                else
                {
                    try
                    {
                        hero.eliminations = jsonresult2[hero.name]["Eliminations"];
                    }
                    catch(Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
                gridView.Items.Add(hero);
            }
        }
    }
}
