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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.Starcraft_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
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
    }
}
