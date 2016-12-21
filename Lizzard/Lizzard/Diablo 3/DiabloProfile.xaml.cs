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

namespace Lizzard.Diablo_3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DiabloProfile : Page
    {
        public DiabloProfile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadMembers();
            loadCareerInformation();
        }

        private async void loadCareerInformation()
        {
            D3Api call = new D3Api();
            var result = await call.get("/profile/" + "RedZerg%231884" + "/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);
            txtCareerInfo.Text =
                "BattleTag: " + jsonresult.battleTag + Environment.NewLine +
                "Paragon level: " + jsonresult.paragonLevel + Environment.NewLine +
                "Guild: " + jsonresult.guildName + Environment.NewLine +
                "Amount of heroes: " + jsonresult.heroes.Count.ToString() + Environment.NewLine + Environment.NewLine +
                "Total monster kills: " + jsonresult.kills.monsters.ToString() + Environment.NewLine +
                "Total elite kills: " + jsonresult.kills.elites.ToString() + Environment.NewLine +
                "Total hardcore monster kills: " + jsonresult.kills.hardcoreMonsters.ToString() + Environment.NewLine + Environment.NewLine +
                "Season 6 paragon level: " + jsonresult.seasonalProfiles.season5.paragonLevel.ToString() + Environment.NewLine +
                "Season 5 paragon level: " + jsonresult.seasonalProfiles.season4.paragonLevel.ToString() + Environment.NewLine +
                "Season 4 paragon level: " + jsonresult.seasonalProfiles.season3.paragonLevel.ToString() + Environment.NewLine +
                "Season 3 paragon level: " + jsonresult.seasonalProfiles.season2.paragonLevel.ToString() + Environment.NewLine +
                "Season 2 paragon level: " + jsonresult.seasonalProfiles.season1.paragonLevel.ToString() + Environment.NewLine +
                "Season 1 paragon level: " + jsonresult.seasonalProfiles.season0.paragonLevel.ToString() + Environment.NewLine;
        }
            

        private async void loadMembers()
        {
            D3Api call = new D3Api();
            var result = await call.get("/profile/" + "RedZerg%231884" + "/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);
            foreach (Hero h in jsonresult.heroes)
            {
                if (h.@class == "barbarian")
                {
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/barbarian_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/barbarian_female.png";
                    }
                }

                if (h.@class == "witch-doctor")
                {
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/witchdoctor_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/witchdoctor_female.png";
                    }
                }

                if (h.@class == "wizard")
                {
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/wizard_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/wizard_female.png";
                    }
                }

                if (h.@class == "monk")
                {
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/monk_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/monk_female.png";
                    }
                }

                if (h.@class == "demon-hunter")
                {
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/demonhunter_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/demonhunter_female.png";
                    }
                }

                if (h.@class == "crusader")
                {
                    if (h.gender == 0)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/crusader_male.png";
                    }
                    if (h.gender == 1)
                    {
                        h.icon = "http://media.blizzard.com/d3/icons/portraits/64/crusader_female.png";
                    }
                }

                gridView.Items.Add(h);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }
    }
}
