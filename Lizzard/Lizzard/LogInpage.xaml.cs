using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

/// <summary>
/// Login Page.
/// </summary>
namespace Lizzard
{
    /// <summary>
    /// A login page to get the battletag of a user
    /// </summary>
    public sealed partial class LogInpage : Page
    {
        public LogInpage()
        {
            this.InitializeComponent();
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
                Frame.Navigate(typeof(MainPage), user);
            }
            else
            {
                //implement error message
            }
        }
    }
}
