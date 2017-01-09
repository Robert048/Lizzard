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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RealmStatus : Page
    {
        public RealmStatus()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadRealms();
        }

        private async void loadRealms()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("realm/status?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectRealms>(result);
            progressRealms.IsActive = false;
            foreach (RealmStats realm in jsonresult.realms)
            {
                realm.population = realm.population + " population";
                if(realm.status == true)
                {
                    realm.icon = "http://www.helios.de/support/manuals/msUB64-e/green.png";
                }
                if(realm.status == false)
                {
                    realm.icon = "http://www.helios.de/support/manuals/msUB64-e/red.png";
                }
                gridView.Items.Add(realm);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
