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
                if(card.collectible == true && card.type != "Hero")
                gridView.Items.Add(card);
            }
            foreach (Classic card in jsonresult.Classic)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (Promo card in jsonresult.Promo)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (Reward card in jsonresult.Reward)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (Naxxrama card in jsonresult.Naxxramas)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (GoblinsVsGnome card in jsonresult.GoblinsVSGnomes)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (BlackrockMountain card in jsonresult.BlackrockMountain)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (TheGrandTournament card in jsonresult.TheGrandTournament)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (TheLeagueOfExplorer card in jsonresult.TheLeagueofExplorers)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (WhispersOfTheOldGod card in jsonresult.WhispersOfTheOldGods)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (Karazhan card in jsonresult.Karazhan)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (MeanStreetsOfGadgetzan card in jsonresult.MeanStreetsOfGadgetzan)
            {
                if (card.collectible == true && card.type != "Hero")
                    gridView.Items.Add(card);
            }
            foreach (HeroSkin card in jsonresult.HeroSkins)
            {
                if (card.collectible == true && card.type != "Hero")
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
            if (listCards.Items.Count < 30)
            {
                if (listCards.Items.Contains(card))
                {
                    var type = card.GetType();
                    switch (type.Name)
                    {
                        case "Basic":
                            Basic selectedCard = (Basic)card;
                            if (selectedCard.name.Substring(0, 2) != "2x")
                            {
                                selectedCard.name = "2x " + selectedCard.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(selectedCard);
                            }
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    listCards.Items.Add(card);
                }
            }
        }

        private void listCards_ItemClick(object sender, ItemClickEventArgs e)
        {
            listCards.Items.Remove(e.ClickedItem);
            Basic card = (Basic)e.ClickedItem;
            if(card.name.Contains("2x"))
            {
                card.name = card.name.Substring(3);
                listCards.Items.Add(card);
            }
        }
    }
}
