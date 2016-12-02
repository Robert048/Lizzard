using Newtonsoft.Json;
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
            foreach(Hero hero in jsonresult)
            {
                
            }
        }
    }
}
