using Newtonsoft.Json;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// World of warcraft guild search page

namespace Lizzard.World_of_Warcraft
{

    public sealed partial class Guild : Page
    {
        private string guildName;
        private string realm;
        public Guild()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Load all recent guild activity using an API call and insert this information in a grid
        /// </summary>
        private async void loadGuildActivity()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("guild/" + realm + "/" + guildName + "?fields=news%2Cchallenge&");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectGuildNews>(result);
            progressGuildActivity.IsActive = false;
            progressGuildMembers.IsActive = false;
            if (jsonresult.name != null)
            {
                foreach (News news in jsonresult.news)
                {
                    if (news.type == "itemLoot")
                    {
                        call = new WoWApi();
                        var itemResult = await call.get("item/" + news.itemId.ToString() + "?");
                        var jsonresults = JsonConvert.DeserializeObject<RootObjectItem>(itemResult);

                        news.type = news.character + " has recieved " + jsonresults.name;
                        gridViewNews.Items.Add(news);
                    }
                }
                loadMembers();
            }
        }

        /// <summary>
        /// Load item information with use of item ID and an API call
        /// </summary>
        /// <param name="itemId">ID of the item</param>
        /// <returns>Item object</returns>
        private async Task<RootObjectItem> getItem(int itemId)
        {
            WoWApi call = new WoWApi();
            var result = await call.get("item/" + itemId.ToString() + "?");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectItem>(result);
            return jsonresult;
        }

        /// <summary>
        /// Load all guild members using an API call and insert all this information in a grid. The names are clickable and navigate to the character search page.
        /// </summary>
        private async void loadMembers()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("guild/" + realm + "/" + guildName + "?fields=members&");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectGuildMembers>(result);
            progressGuildMembers.IsActive = false;
            foreach (Member m in jsonresult.members)
            {
                m.character.thumbnail = "http://render-api-eu.worldofwarcraft.com/static-render/eu/" + m.character.thumbnail;
                gridView.Items.Add(m.character);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                progressGuildActivity.IsActive = true;
                progressGuildMembers.IsActive = true;
                guildName = txtGuildName.Text;
                realm = txtRealm.Text;
                loadGuildActivity();
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Navigate to character search page when clicked on a specific name of a guild member in the grid. After loading guild members
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendGuildMember(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var parameters = new Character();
            parameters.name = ((TextBlock)sender).Text;
            parameters.realm = ((TextBlock)sender).Tag.ToString();

            Frame.Navigate(typeof(Profile), parameters);
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
