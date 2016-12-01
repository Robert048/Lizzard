using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Lizzard.Overwatch
{
    /// <summary>
    /// Het overwatch mainscherm
    /// </summary>
    public sealed partial class OverwatchMainPage : Page
    {
        private User user;
        private DataProfile data;

        public OverwatchMainPage()
        {
            this.InitializeComponent();
        }

        private async void getProfile()
        {
            Api call = new Api();
            var result = await call.get(user.platform + "/" + user.region + "/" + user.tag + "/profile");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);
            data = jsonresult.data;
            if (data.avatar != null && data.username != null)
            {
                image.Source = new BitmapImage(new Uri(data.avatar, UriKind.Absolute));
                txtData.Text = data.username + System.Environment.NewLine + "Level: " + data.level;
                progressRing.IsActive = false;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnLifetime_Click(object sender, RoutedEventArgs e)
        {
            if (data != null)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("data", data);
                parameters.Add("user", user);
                Frame.Navigate(typeof(OverwatchSubPage), parameters);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            User user = (User)e.Parameter;
            this.user = user;
            getProfile();
        }
    }
}
