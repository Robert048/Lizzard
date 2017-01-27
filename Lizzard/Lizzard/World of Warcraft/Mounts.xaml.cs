using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// World of Warcraft page with a list of all available mounts
    /// </summary>
    public sealed partial class Mounts : Page
    {
        public Mounts()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadMounts();
        }

        /// <summary>
        /// Load all mounts using an API call and inserting it with name and icon into the grid
        /// </summary>
        private async void loadMounts()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("mount/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectMount>(result);
            progressMounts.IsActive = false;
            foreach (Mount m in jsonresult.mounts)
            {
                m.icon = "http://wow.zamimg.com/images/wow/icons/large/" + m.icon + ".jpg";
                gridView.Items.Add(m);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
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
