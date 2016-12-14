using Newtonsoft.Json;
using System;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard.Hearthstone
{
    /// <summary>
    /// Hearthstone page to make a carddeck
    /// </summary>
    public sealed partial class CreateDeckPage : Page
    {
        public CreateDeckPage()
        {
            this.InitializeComponent();
            loadCards();
        }

        private async void loadCards()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var files = await folder.GetFilesAsync();
            var cardFile = files.FirstOrDefault(x => x.Name == "cards.txt");
            var result = await FileIO.ReadTextAsync(cardFile);
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);

            foreach(Basic card in jsonresult.Basic)
            {
                gridView.Items.Add(card);
            }
            foreach (Classic card in jsonresult.Classic)
            {
                gridView.Items.Add(card);
            }
            foreach (Promo card in jsonresult.Promo)
            {
                gridView.Items.Add(card);
            }
            foreach (Reward card in jsonresult.Reward)
            {
                gridView.Items.Add(card);
            }
            foreach (Naxxrama card in jsonresult.Naxxramas)
            {
                gridView.Items.Add(card);
            }
            foreach (GoblinsVsGnome card in jsonresult.GoblinsVSGnomes)
            {
                gridView.Items.Add(card);
            }
            foreach (BlackrockMountain card in jsonresult.BlackrockMountain)
            {
                gridView.Items.Add(card);
            }
            foreach (TheGrandTournament card in jsonresult.TheGrandTournament)
            {
                gridView.Items.Add(card);
            }
            foreach (TheLeagueOfExplorer card in jsonresult.TheLeagueofExplorers)
            {
                gridView.Items.Add(card);
            }
            foreach (WhispersOfTheOldGod card in jsonresult.WhispersOfTheOldGods)
            {
                gridView.Items.Add(card);
            }
            foreach (Karazhan card in jsonresult.Karazhan)
            {
                gridView.Items.Add(card);
            }
            foreach (MeanStreetsOfGadgetzan card in jsonresult.MeanStreetsOfGadgetzan)
            {
                gridView.Items.Add(card);
            }
            foreach (TavernBrawl card in jsonresult.TavernBrawl)
            {
                gridView.Items.Add(card);
            }
            foreach (HeroSkin card in jsonresult.HeroSkins)
            {
                gridView.Items.Add(card);
            }
            foreach (Mission card in jsonresult.Missions)
            {
                gridView.Items.Add(card);
            }
            foreach (Credit card in jsonresult.Credits)
            {
                gridView.Items.Add(card);
            }
            foreach (Debug card in jsonresult.Debug)
            {
                gridView.Items.Add(card);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void gridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var card = e.ClickedItem;
            listCards.Items.Add(card);

        }
    }
}
