using Newtonsoft.Json;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Navigation;


namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// Realm status page to show all realms and their status
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

        /// <summary>
        /// Load all available game realms using an API call. Shows if the server is online or offline.
        /// </summary>
        private async void loadRealms()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("realm/status?");
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
