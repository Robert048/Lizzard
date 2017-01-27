using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// World of Warcraft main navigation page

namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// World of warcraft navigation page
    /// </summary>
    public sealed partial class MainPage : Page
    {
        User user;
        public string charName;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Profile), charName);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Guild));
        }

        private void btnRealmPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RealmStatus));
        }

        private void btnAllMounts(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Mounts));
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
