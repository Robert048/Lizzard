using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System;

namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// Heroes of the Storm page with all the hero names of the game
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
            var result = await call.getData("Data/Heroes");
            var jsonresult = JsonConvert.DeserializeObject<List<Hero>>(result);
            foreach (var hero in jsonresult)
            {
                listHeroes.Items.Add(hero);
            }
            progressRing.IsActive = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
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
