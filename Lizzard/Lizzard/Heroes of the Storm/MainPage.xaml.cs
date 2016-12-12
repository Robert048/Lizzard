using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard.Heroes_of_the_Storm
{
    /// <summary>
    /// Mainpage Heroes of the Storm
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }

        private async void getProfile()
        {
            Api call = new Api();
            var result = await call.get("2/Mandela_2595");
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);
        }

        private void btnMaps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapsPage));
        }

        private void btnHeroes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HeroesPage));
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StatsPage));
        }
    }
}
