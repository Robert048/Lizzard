using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Lizzard.Diablo_3
{
    /// <summary>
    /// Diablo 3 specific follower page
    /// </summary>
    public sealed partial class Follower : Page
    {
        //Name of clicked follower
        private string followerName = "";

        public Follower()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter.ToString() == "templar")
            {
                followerName = e.Parameter.ToString();
                txtFollower.Text = followerName;
                imgFollowerSet.Source = new BitmapImage(new Uri("http://www.diablowiki.net/images/9/90/Templarportrait.jpg", UriKind.Absolute));
                ringIcon.IsActive = false;
            }
            if (e.Parameter.ToString() == "scoundrel")
            {
                followerName = e.Parameter.ToString();
                txtFollower.Text = followerName;
                imgFollowerSet.Source = new BitmapImage(new Uri("http://www.diablowiki.net/images/4/49/Scoundrel-portrait.png", UriKind.Absolute));
                ringIcon.IsActive = false;

            }
            if (e.Parameter.ToString() == "enchantress")
            {
                followerName = e.Parameter.ToString();
                txtFollower.Text = followerName;
                imgFollowerSet.Source = new BitmapImage(new Uri("http://www.diablowiki.net/images/6/61/Enchantress-portrait.png", UriKind.Absolute));
                ringIcon.IsActive = false;

            }
            loadFollowerData();
        }

        /// <summary>
        /// API call to load all follower data
        /// </summary>
        public async void loadFollowerData()
        {
            Api call = new Api();
            var result = await call.get("/data/follower/" + followerName + "?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectFollower>(result);
            ringSkills.IsActive = false;
            foreach (Active skill in jsonresult.skills.active)
            {
                skill.icon = "http://media.blizzard.com/d3/icons/skills/64/" + skill.icon +".png";
                gridView.Items.Add(skill);
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Diablo_3.Followers));
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
