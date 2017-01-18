using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Lizzard.Overwatch
{
    /// <summary>
    /// Het overwatch mainscherm
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private User user;
        private DataProfile data;
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
            var tag = localSettings.Values["tag"];
            if (tag != null)
            {
                this.user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"], platform = (string)localSettings.Values["platform"] };
                getProfile();
            }
            else
            {
                Frame.Navigate(typeof(LogInpage));
            }
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
            Frame.Navigate(typeof(Lizzard.MainPage));
        }

        private void btnLifetime_Click(object sender, RoutedEventArgs e)
        {
            if (data != null)
            {
                Frame.Navigate(typeof(StatPage), data);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void btnHeroesQuick_Click(object sender, RoutedEventArgs e)
        {
            if (data != null)
            {
                Frame.Navigate(typeof(QuickPlayPage), data);
            }
        }

        private void btnHeroesComp_Click(object sender, RoutedEventArgs e)
        {
            if (data != null)
            {
                Frame.Navigate(typeof(CompetitivePage), data);
            }
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
