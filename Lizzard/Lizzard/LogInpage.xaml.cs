using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard
{
    /// <summary>
    /// A login page to get the battletag and region of a user
    /// </summary>
    public sealed partial class LogInpage : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public LogInpage()
        {
            this.InitializeComponent();
            var tag = localSettings.Values["tag"];
            if (tag != null)
            {
                User user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"], platform = (string)localSettings.Values["platform"] };
                txtUsername.Text = user.tag;
                txtRegion.Text = user.region;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "" && txtRegion.Text != "")
            {
                string username = txtUsername.Text;
                if (username.Contains("#"))
                {
                    username = username.Replace("#", "-");
                }
                User user = new User { tag = username, region = txtRegion.Text, platform = "pc" };
                localSettings.Values["tag"] = user.tag;
                localSettings.Values["region"] = user.region;
                localSettings.Values["platform"] = user.platform;
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                //implement error message
            }
        }
    }
}
