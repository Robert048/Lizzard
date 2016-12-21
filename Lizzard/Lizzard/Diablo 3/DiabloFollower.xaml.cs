using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lizzard.Diablo_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DiabloFollower : Page
    {
        string followerName = "";

        public DiabloFollower()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter.ToString() == "templar")
            {
                followerName = e.Parameter.ToString();
                imgFollowerSet.Source = new BitmapImage(new Uri("http://www.diablowiki.net/images/9/90/Templarportrait.jpg", UriKind.Absolute));
            }
            if (e.Parameter.ToString() == "scoundrel")
            {
                followerName = e.Parameter.ToString();
                imgFollowerSet.Source = new BitmapImage(new Uri("http://www.diablowiki.net/images/4/49/Scoundrel-portrait.png", UriKind.Absolute));
            }
            if (e.Parameter.ToString() == "enchantress")
            {
                followerName = e.Parameter.ToString();
                imgFollowerSet.Source = new BitmapImage(new Uri("http://www.diablowiki.net/images/6/61/Enchantress-portrait.png", UriKind.Absolute));
            }
            loadFollowerData();
        }

        public async void loadFollowerData()
        {
            D3Api call = new D3Api();
            var result = await call.get("/data/follower/" + followerName + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectFollower>(result);
            foreach (Active skill in jsonresult.skills.active)
            {
                skill.icon = "http://media.blizzard.com/d3/icons/skills/64/" + skill.icon +".png";
                gridView.Items.Add(skill);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Diablo_3.DiabloFollowers));
        }
    }
}
