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
            boxRegion.Items.Add("eu");
            boxRegion.Items.Add("us");
            boxRegion.Items.Add("kr");
            boxRegion.Items.Add("cn");
            boxRegion.Items.Add("xbl");
            boxRegion.Items.Add("psn");
            var tag = localSettings.Values["tag"];
            if (tag != null)
            {
                User user = new User { tag = (string)localSettings.Values["tag"], region = (string)localSettings.Values["region"], platform = (string)localSettings.Values["platform"] };
                txtUsername.Text = user.tag;
                boxRegion.SelectedValue = user.region;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "" && boxRegion.SelectedIndex != -1)
            {
                string username = txtUsername.Text;
                if (username.Contains("#"))
                {
                    username = username.Replace("#", "-");
                }
                User user;
                if(boxRegion.SelectedValue.ToString() == "psn" || boxRegion.SelectedValue.ToString() == "xbl")
                {
                    user = new User { tag = username, region = "global", platform = boxRegion.SelectedValue.ToString() };
                }
                else
                {
                    user = new User { tag = username, region = boxRegion.SelectedValue.ToString(), platform = "pc" };
                }
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

        private void grid_SizeChanged(object sender, SizeChangedEventArgs e)
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
