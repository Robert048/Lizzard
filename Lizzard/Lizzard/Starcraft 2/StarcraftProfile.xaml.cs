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

namespace Lizzard.Starcraft_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StarcraftProfile : Page
    {

        public StarcraftProfile()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadProfileInformation();
        }

        private async void loadProfileInformation()
        {
            SC2Api call = new SC2Api();


            var result = await call.get("/profile/" + "2690538/1/Rainy/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);
            txtProfile.Text =
                "Name: " + jsonresult.displayName + Environment.NewLine +
                "Clan name: " + jsonresult.clanName + Environment.NewLine +
                "Clan tag: " + jsonresult.clanTag + Environment.NewLine + Environment.NewLine +
                "Achievement points: " + jsonresult.achievements.points.totalPoints.ToString() + Environment.NewLine +
                "Primary race: " + jsonresult.career.primaryRace + Environment.NewLine +
                "Highest 1v1 rank: " + jsonresult.career.highest1v1Rank + Environment.NewLine +
                "Highest team rank: " + jsonresult.career.highestTeamRank + Environment.NewLine + Environment.NewLine;

            txtZergLvl.Text = jsonresult.swarmLevels.zerg.level.ToString();
            txtTerranLvl.Text = jsonresult.swarmLevels.terran.level.ToString();
            txtProtossLvl.Text = jsonresult.swarmLevels.protoss.level.ToString();

            double terranCurrentExp = jsonresult.swarmLevels.terran.currentLevelXP;
            double terranTotalExp = jsonresult.swarmLevels.terran.totalLevelXP;

            double zergCurrentExp = jsonresult.swarmLevels.zerg.currentLevelXP;
            double zergTotalExp = jsonresult.swarmLevels.zerg.totalLevelXP;

            double protosCurrentExp = jsonresult.swarmLevels.protoss.currentLevelXP;
            double protosTotalExp = jsonresult.swarmLevels.protoss.totalLevelXP;

            double terVal = terranCurrentExp / terranTotalExp * 100;
            double zergVal = zergCurrentExp / zergTotalExp * 100;
            double proVal = protosCurrentExp / protosTotalExp * 100;

            prgTerran.Value = terVal;
            prgZerg.Value = zergVal;
            prgProtoss.Value = proVal;


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.Starcraft_2.MainPage));
        }
    }
}
