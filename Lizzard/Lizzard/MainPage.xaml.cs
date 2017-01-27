using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lizzard
{
    /// <summary>
    /// Mainpage of the Lizzard Application
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnWOW_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(World_of_Warcraft.MainPage));
        }

        private void btnD3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Diablo_3.MainPage));
        }

        private void btnSC2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Starcraft_2.InputInfo));
        }

        private void btnOW_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Overwatch.MainPage));
        }

        private void btnHS_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Hearthstone.MainPage));
        }

        private void btnHotS_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Heroes_of_the_Storm.MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //reset localsettings of logged in user
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["tag"] = "";
            localSettings.Values["region"] = "";
            localSettings.Values["platform"] = "";
            Frame.Navigate(typeof(LogInpage));
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
