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
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["tag"] = "";
            localSettings.Values["region"] = "";
            localSettings.Values["platform"] = "";
            Frame.Navigate(typeof(LogInpage));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
