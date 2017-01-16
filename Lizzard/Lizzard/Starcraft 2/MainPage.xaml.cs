using Newtonsoft.Json;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace Lizzard.Starcraft_2
{
    /// <summary>
    /// StarCraft II mainpage
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;


        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadProfileInformation();
        }

        private async void loadProfileInformation()
        {
            try {
                SC2Api call = new SC2Api();

                // "2690538
                var id = localSettings.Values["id"];
                StarcraftUser user = new StarcraftUser { id = (string)localSettings.Values["id"], name = (string)localSettings.Values["name"] };

                var result = await call.get("/profile/" + user.id + "/1/" + user.name + "/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
                var jsonresult = JsonConvert.DeserializeObject<RootObjectProfile>(result);

                prgrProf.IsActive = false;
                if (jsonresult.clanName != "")
                {
                    txtProfile.Text =
                    "Name: " + jsonresult.displayName + Environment.NewLine +
                    "Clan name: " + jsonresult.clanName + Environment.NewLine +
                    "Clan tag: " + jsonresult.clanTag + Environment.NewLine + Environment.NewLine +
                    "Achievement points: " + jsonresult.achievements.points.totalPoints.ToString() + Environment.NewLine +
                    "Primary race: " + jsonresult.career.primaryRace + Environment.NewLine +
                    "Highest 1v1 rank: " + jsonresult.career.highest1v1Rank + Environment.NewLine +
                    "Highest team rank: " + jsonresult.career.highestTeamRank + Environment.NewLine + Environment.NewLine;
                }

                else
                {
                    txtProfile.Text =
                    "Name: " + jsonresult.displayName + Environment.NewLine +
                    "Achievement points: " + jsonresult.achievements.points.totalPoints.ToString() + Environment.NewLine +
                    "Primary race: " + jsonresult.career.primaryRace + Environment.NewLine +
                    "Highest 1v1 rank: " + jsonresult.career.highest1v1Rank + Environment.NewLine +
                    "Highest team rank: " + jsonresult.career.highestTeamRank + Environment.NewLine + Environment.NewLine;
                }


                prgrsZrg.IsActive = false;
                txtZergLvl.Text = jsonresult.swarmLevels.zerg.level.ToString();
                prgrTerran.IsActive = false;
                txtTerranLvl.Text = jsonresult.swarmLevels.terran.level.ToString();
                prgrsProt.IsActive = false;
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
            catch(Exception e)
            {
                var dialog = new MessageDialog("No information on this Starcraft user.");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(InputInfo));
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lizzard.MainPage));
        }
    }
}
