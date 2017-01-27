
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.Starcraft_2
{
    /// <summary>
    /// Starcraft 2 input information page
    /// </summary>
    public sealed partial class InputInfo : Page
    {

        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public InputInfo()
        {
            this.InitializeComponent();
            
            var id = localSettings.Values["id"];
            if (id != null)
            {
                StarcraftUser user = new StarcraftUser { id = (string)localSettings.Values["id"], name = (string)localSettings.Values["name"]};
                txtScId.Text = user.id;
                txtScName.Text = user.name;
            }
        }
        
        /// <summary>
        /// Setup starcraft user in local settings and navigate to starcraft mainpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterInfo(object sender, RoutedEventArgs e)
        {

            StarcraftUser user = new StarcraftUser { id = txtScId.Text, name = txtScName.Text};
            localSettings.Values["id"] = user.id;
            localSettings.Values["name"] = user.name;

            Frame.Navigate(typeof(MainPage));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
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
