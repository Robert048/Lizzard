using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        User user;
        public MainPage()
        {
            this.InitializeComponent();
            user = new User { tag = "Bobgast-2232", region="eu", platform = "pc"};
        }

        private void btnWOW_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WorldOfWarcraftMainPage));
        }

        private void btnD3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DiabloMainPage));
        }

        private void btnSC2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StarCraftMainPage));
        }

        private void btnOW_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OverwatchMainPage), user);
        }

        private void btnHS_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HearthstoneMainPage));
        }

        private void btnHotS_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HeroesOfTheStormMainPage));
        }
    }
}
