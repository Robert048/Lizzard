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
            Frame.Navigate(typeof(DiabloMainPage));
        }

        private void btnSC2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StarCraftMainPage));
        }

        private void btnOW_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Overwatch.MainPage));
        }

        private void btnHS_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HearthstoneMainPage));
        }

        private void btnHotS_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HeroesOfTheStormMainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
