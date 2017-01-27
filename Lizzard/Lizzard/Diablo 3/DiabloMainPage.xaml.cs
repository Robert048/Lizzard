using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Lizzard.Diablo_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void textBlock_SelectionChanged(System.Object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Profile));

        }

        private void btnFollowers_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Followers));
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
