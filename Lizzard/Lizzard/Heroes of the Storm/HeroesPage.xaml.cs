﻿using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System;

namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// Heroes of the Storm hero page
    /// </summary>
    public sealed partial class HeroesPage : Page
    {
        public HeroesPage()
        {
            this.InitializeComponent();
            getHeroes();
        }

        private async void getHeroes()
        {
            Api call = new Api();
            var result = await call.get("Data/Heroes");
            var jsonresult = JsonConvert.DeserializeObject<List<Hero>>(result);
            foreach (var hero in jsonresult)
            {
                txtHeroes.Text = txtHeroes.Text + hero.PrimaryName + Environment.NewLine;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}