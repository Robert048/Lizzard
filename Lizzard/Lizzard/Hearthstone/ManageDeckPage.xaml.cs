using Windows.Storage;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lizzard.Hearthstone
{
    /// <summary>
    /// Hearthstone page to manage the saved carddecks
    /// </summary>
    public sealed partial class ManageDeckPage : Page
    {
        public ManageDeckPage()
        {
            this.InitializeComponent();
            loadDecks();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void loadDecks()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var files = await folder.GetFilesAsync();
            var deckFile = files.FirstOrDefault(x => x.Name == "cardDecks.txt");
            string result = await FileIO.ReadTextAsync(deckFile);
            result = result.TrimEnd(result[result.Length -1]);
            List<string> cards = result.Split(',').ToList();

            
            var cardFile = files.FirstOrDefault(x => x.Name == "cards.txt");
            var result2 = await FileIO.ReadTextAsync(cardFile);
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result2);

            foreach (var cardID in cards)
            {
                foreach (Basic card in jsonresult.Basic)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (Classic card in jsonresult.Classic)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (Promo card in jsonresult.Promo)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (Reward card in jsonresult.Reward)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (Naxxrama card in jsonresult.Naxxramas)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (GoblinsVsGnome card in jsonresult.GoblinsVSGnomes)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (BlackrockMountain card in jsonresult.BlackrockMountain)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (TheGrandTournament card in jsonresult.TheGrandTournament)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (TheLeagueOfExplorer card in jsonresult.TheLeagueofExplorers)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (WhispersOfTheOldGod card in jsonresult.WhispersOfTheOldGods)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (Karazhan card in jsonresult.Karazhan)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (MeanStreetsOfGadgetzan card in jsonresult.MeanStreetsOfGadgetzan)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
                foreach (HeroSkin card in jsonresult.HeroSkins)
                {
                    if (cardID == card.cardId)
                        gridView.Items.Add(card);
                }
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
