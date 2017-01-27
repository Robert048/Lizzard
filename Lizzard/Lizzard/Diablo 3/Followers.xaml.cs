using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Lizzard.Diablo_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Followers : Page
    {
        public Followers()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void imgTemplar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string name = "templar";
            Frame.Navigate(typeof(Diablo_3.Follower), name);

        }

        private void imgScoundrel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string name = "scoundrel";
            Frame.Navigate(typeof(Diablo_3.Follower), name);
        }

        private void imgEnchantress_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string name = "enchantress";
            Frame.Navigate(typeof(Diablo_3.Follower), name);
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
