using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Lizzard
{
    /// <summary>
    /// Het overwatch mainscherm
    /// </summary>
    public sealed partial class OverwatchMainPage : Page
    {
        private string tag = "Bobgast-2232";
        private string region = "eu";
        private string platform = "pc";

        public OverwatchMainPage()
        {
            getProfile();
            this.InitializeComponent();
        }

        private async void getProfile()
        {
            Api call = new Api();
            Data data = await call.get("https://api.lootbox.eu/" + platform + "/" + region + "/" + tag + "/profile");
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
    }
}
