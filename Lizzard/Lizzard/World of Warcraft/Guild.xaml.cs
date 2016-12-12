using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Guild : Page
    {
        private string guildName;
        private string region;
        private string realm;
        public Guild()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private async void loadGuildActivity()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("guild/" + realm + "/" + guildName + "?fields=news%2Cchallenge&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectGuildNews>(result);
            foreach (News news in jsonresult.news)
            {
                if (news.type == "itemLoot")
                {
                    call = new WoWApi();
                    var itemResult = await call.get("item/" + news.itemId.ToString() + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
                    var jsonresults = JsonConvert.DeserializeObject<RootObjectItem>(itemResult);

                    news.type = news.character + " has recieved " + jsonresults.name;  
                    gridViewNews.Items.Add(news);
                }
            }
        }

        private async Task<RootObjectItem> getItem(int itemId)
        {
            WoWApi call = new WoWApi();
            var result = await call.get("item/" + itemId.ToString() + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectItem>(result);
            return jsonresult;
        }

        private async void loadMembers()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("guild/" + realm + "/" + guildName + "?fields=members&locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectGuildMembers>(result);
            foreach(Member m in jsonresult.members)
            {
                m.character.thumbnail = "http://render-api-eu.worldofwarcraft.com/static-render/eu/" + m.character.thumbnail;
                gridView.Items.Add(m.character);
            }
        }

        private void btnBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }



        private void btnSearch_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                guildName = txtGuildName.Text;
                region = txtRegion.Text;
                realm = txtRealm.Text;
                loadGuildActivity();
                loadMembers();
                textBlock1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                textBlock3.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            catch
            {
                //showError();

            }
        }
    }
}
