using Newtonsoft.Json;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// World of Warcraft character search page
    /// </summary>
    public sealed partial class Profile : Page
    {
        private string charName;
        private string realm;

        public Profile()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When navigated from the guild search page already insert and load the specific character to search for
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if(e.Parameter != null)
            {
                var parameters = (Character)e.Parameter;
                txtCharName.Text = parameters.name;
                txtRealm.Text = parameters.realm;
                try
                {
                    charName = txtCharName.Text;
                    realm = txtRealm.Text;
                    loadProfileData();
                }
                catch
                {

                }
            }
        }
        
        /// <summary>
        /// Load all profile data of the inserted character name
        /// </summary>
        private async void loadProfileData()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/" + realm + "/" + charName + "?");
            var jsonresult = JsonConvert.DeserializeObject<CharacterInformation>(result);
            ringInfo.IsActive = false;
            if (jsonresult.name != null)
            {
                txtProfile.Text =
                    "Name: " + jsonresult.name + Environment.NewLine +
                    "Level: " + jsonresult.level.ToString() + Environment.NewLine +
                    "Achievement points: " + jsonresult.achievementPoints.ToString() + Environment.NewLine +
                    "Total Honorable Kills: " + jsonresult.totalHonorableKills.ToString() + Environment.NewLine +
                    "Realm: " + jsonresult.realm.ToString();

                loadIconProfileData();
                loadActivity();
                loadStats();
                loadItems();
                txtItems.Visibility = Visibility.Visible;
                txtProfile.Visibility = Visibility.Visible;
                txtStats.Visibility = Visibility.Visible;
                textBlock.Visibility = Visibility.Visible;
                textBlock1.Visibility = Visibility.Visible;
                textBlock2.Visibility = Visibility.Visible;
                textBlock3.Visibility = Visibility.Visible;
            }
            else
            {
                ringActivity.IsActive = false;
                ringStats.IsActive = false;
                ringItems.IsActive = false;
                txtProfile.Text = "No character found";
            }
        }

        /// <summary>
        /// Load character icon of the isnerted character name using an API call
        /// </summary>
        private async void loadIconProfileData()
        {

            WoWApi call = new WoWApi();
            var result = await call.get("character/" + realm + "/" + charName + "?");
            var jsonresult = JsonConvert.DeserializeObject<CharacterInformation>(result);
            image.Source = new BitmapImage(new Uri("http://render-api-eu.worldofwarcraft.com/static-render/eu/" + jsonresult.thumbnail));
        }

        /// <summary>
        /// Load recent activity of the inserted character name using an API call
        /// </summary>
        private async void loadActivity()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/" + realm + "/" + charName + "?fields=feed&");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectFeed>(result);
            ringActivity.IsActive = false;

            foreach (Feed feed in jsonresult.feed)
            {
                if (feed.type == "LOOT")
                {
                    call = new WoWApi();
                    var itemResult = await call.get("item/" + feed.itemId.ToString() + "?");
                    var jsonresults = JsonConvert.DeserializeObject<RootObjectItem>(itemResult);

                    feed.type = jsonresult.name + " has recieved " + jsonresults.name;
                    gridViewFeed.Items.Add(feed);
                }
            }
        }

        /// <summary>
        /// Load all character stats of the inserted character name using an API call
        /// </summary>
        private async void loadStats()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/" + realm + "/" + charName + "?fields=stats&");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectStats>(result);
            ringStats.IsActive = false;
            txtStats.Text =
                "Health: " + jsonresult.stats.health.ToString() + Environment.NewLine +
                "Mana: " + jsonresult.stats.power.ToString() + Environment.NewLine +
                "Strength: " + jsonresult.stats.str.ToString() + Environment.NewLine +
                "Agility: " + jsonresult.stats.agi.ToString() + Environment.NewLine +
                "Intellect: " + jsonresult.stats.@int.ToString() + Environment.NewLine +
                "Stamina: " + jsonresult.stats.sta.ToString() + Environment.NewLine +
                "Critical rating: " + jsonresult.stats.crit.ToString() + Environment.NewLine +
                "Haste rating: " + jsonresult.stats.haste.ToString() + Environment.NewLine;
        }


        /// <summary>
        /// Load all items equipped by the inserted character using an API call
        /// </summary>
        private async void loadItems()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("character/" + realm + "/" + charName + "?fields=items&");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectItems>(result);
            ringItems.IsActive = false;
            txtItems.Text =
                "Equipped item level: " + jsonresult.items.averageItemLevelEquipped.ToString() + Environment.NewLine +
                "Item level: " + jsonresult.items.averageItemLevel.ToString() + Environment.NewLine +
                "Chest: " + jsonresult.items.chest.name.ToString() + Environment.NewLine +
                "Back: " + jsonresult.items.back.name.ToString() + Environment.NewLine +
                "Feet: " + jsonresult.items.feet.name.ToString() + Environment.NewLine +
                "Mainhand: " + jsonresult.items.mainHand.name.ToString() + Environment.NewLine +
                "Neck: " + jsonresult.items.neck.name.ToString() + Environment.NewLine;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        
        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ringItems.IsActive = true;
                ringStats.IsActive = true;
                ringActivity.IsActive = true;
                ringInfo.IsActive = true;
                charName = txtCharName.Text;
                realm = txtRealm.Text;
                loadProfileData();

            }
            catch
            {
                var dialog = new MessageDialog("No character found.");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Profile));
            }
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
