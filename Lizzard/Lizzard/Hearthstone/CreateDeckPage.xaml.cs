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
            int count = listCards.Items.Count;
            int doubles = 0;
            foreach (var card2 in listCards.Items)
            {
                var type = card2.GetType();
                switch (type.Name)
                {
                    case "Basic":
                        Basic Basic = (Basic)card2;
                        if (Basic.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "Classic":
                        Classic Classic = (Classic)card2;
                        if (Classic.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "Promo":
                        Promo Promo = (Promo)card2;
                        if (Promo.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "Reward":
                        Reward Reward = (Reward)card2;
                        if (Reward.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "Naxxrama":
                        Naxxrama Naxxrama = (Naxxrama)card2;
                        if (Naxxrama.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "GoblinsVsGnome":
                        GoblinsVsGnome GoblinsVsGnome = (GoblinsVsGnome)card2;
                        if (GoblinsVsGnome.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "BlackrockMountain":
                        BlackrockMountain BlackrockMountain = (BlackrockMountain)card2;
                        if (BlackrockMountain.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "TheGrandTournament":
                        TheGrandTournament TheGrandTournament = (TheGrandTournament)card2;
                        if (TheGrandTournament.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "TheLeagueOfExplorer":
                        TheLeagueOfExplorer TheLeagueOfExplorer = (TheLeagueOfExplorer)card2;
                        if (TheLeagueOfExplorer.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "WhispersOfTheOldGod":
                        WhispersOfTheOldGod WhispersOfTheOldGod = (WhispersOfTheOldGod)card2;
                        if (WhispersOfTheOldGod.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "Karazhan":
                        Karazhan Karazhan = (Karazhan)card2;
                        if (Karazhan.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "MeanStreetsOfGadgetzan":
                        MeanStreetsOfGadgetzan MeanStreetsOfGadgetzan = (MeanStreetsOfGadgetzan)card2;
                        if (MeanStreetsOfGadgetzan.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    case "HeroSkin":
                        HeroSkin HeroSkin = (HeroSkin)card2;
                        if (HeroSkin.name.Contains("2x"))
                        {
                            doubles++;
                        }
                        break;
                    default:
                        break;
                }
            }
            if ((count + doubles) < 30)
            {
                if (listCards.Items.Contains(card))
                {
                    var type = card.GetType();
                    switch (type.Name)
                    {
                        case "Basic":
                            Basic Basic = (Basic)card;
                            if (Basic.name.Substring(0, 2) != "2x")
                            {
                                Basic.name = "2x " + Basic.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(Basic);
                            }
                            break;
                        case "Classic":
                            Classic Classic = (Classic)card;
                            if (Classic.name.Substring(0, 2) != "2x")
                            {
                                Classic.name = "2x " + Classic.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(Classic);
                            }
                            break;
                        case "Promo":
                            Promo Promo = (Promo)card;
                            if (Promo.name.Substring(0, 2) != "2x")
                            {
                                Promo.name = "2x " + Promo.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(Promo);
                            }
                            break;
                        case "Reward":
                            Reward Reward = (Reward)card;
                            if (Reward.name.Substring(0, 2) != "2x")
                            {
                                Reward.name = "2x " + Reward.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(Reward);
                            }
                            break;
                        case "Naxxrama":
                            Naxxrama Naxxrama = (Naxxrama)card;
                            if (Naxxrama.name.Substring(0, 2) != "2x")
                            {
                                Naxxrama.name = "2x " + Naxxrama.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(Naxxrama);
                            }
                            break;
                        case "GoblinsVsGnome":
                            GoblinsVsGnome GoblinsVsGnome = (GoblinsVsGnome)card;
                            if (GoblinsVsGnome.name.Substring(0, 2) != "2x")
                            {
                                GoblinsVsGnome.name = "2x " + GoblinsVsGnome.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(GoblinsVsGnome);
                            }
                            break;
                        case "BlackrockMountain":
                            BlackrockMountain BlackrockMountain = (BlackrockMountain)card;
                            if (BlackrockMountain.name.Substring(0, 2) != "2x")
                            {
                                BlackrockMountain.name = "2x " + BlackrockMountain.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(BlackrockMountain);
                            }
                            break;
                        case "TheGrandTournament":
                            TheGrandTournament TheGrandTournament = (TheGrandTournament)card;
                            if (TheGrandTournament.name.Substring(0, 2) != "2x")
                            {
                                TheGrandTournament.name = "2x " + TheGrandTournament.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(TheGrandTournament);
                            }
                            break;
                        case "TheLeagueOfExplorer":
                            TheLeagueOfExplorer TheLeagueOfExplorer = (TheLeagueOfExplorer)card;
                            if (TheLeagueOfExplorer.name.Substring(0, 2) != "2x")
                            {
                                TheLeagueOfExplorer.name = "2x " + TheLeagueOfExplorer.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(TheLeagueOfExplorer);
                            }
                            break;
                        case "WhispersOfTheOldGod":
                            WhispersOfTheOldGod WhispersOfTheOldGod = (WhispersOfTheOldGod)card;
                            if (WhispersOfTheOldGod.name.Substring(0, 2) != "2x")
                            {
                                WhispersOfTheOldGod.name = "2x " + WhispersOfTheOldGod.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(WhispersOfTheOldGod);
                            }
                            break;
                        case "Karazhan":
                            Karazhan Karazhan = (Karazhan)card;
                            if (Karazhan.name.Substring(0, 2) != "2x")
                            {
                                Karazhan.name = "2x " + Karazhan.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(Karazhan);
                            }
                            break;
                        case "MeanStreetsOfGadgetzan":
                            MeanStreetsOfGadgetzan MeanStreetsOfGadgetzan = (MeanStreetsOfGadgetzan)card;
                            if (MeanStreetsOfGadgetzan.name.Substring(0, 2) != "2x")
                            {
                                MeanStreetsOfGadgetzan.name = "2x " + MeanStreetsOfGadgetzan.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(MeanStreetsOfGadgetzan);
                            }
                            break;
                        case "HeroSkin":
                            HeroSkin HeroSkin = (HeroSkin)card;
                            if (HeroSkin.name.Substring(0, 2) != "2x")
                            {
                                HeroSkin.name = "2x " + HeroSkin.name;
                                listCards.Items.Remove(card);
                                listCards.Items.Add(HeroSkin);
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
            var card = e.ClickedItem;
            
            var type = card.GetType();
            switch (type.Name)
            {
                case "Basic":
                    Basic Basic = (Basic)card;
                    if (Basic.name.Contains("2x"))
                    {
                        Basic.name = Basic.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "Classic":
                    Classic Classic = (Classic)card;
                    if (Classic.name.Contains("2x"))
                    {
                        Classic.name = Classic.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "Promo":
                    Promo Promo = (Promo)card;
                    if (Promo.name.Contains("2x"))
                    {
                        Promo.name = Promo.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "Reward":
                    Reward Reward = (Reward)card;
                    if (Reward.name.Contains("2x"))
                    {
                        Reward.name = Reward.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "Naxxrama":
                    Naxxrama Naxxrama = (Naxxrama)card;
                    if (Naxxrama.name.Contains("2x"))
                    {
                        Naxxrama.name = Naxxrama.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "GoblinsVsGnome":
                    GoblinsVsGnome GoblinsVsGnome = (GoblinsVsGnome)card;
                    if (GoblinsVsGnome.name.Contains("2x"))
                    {
                        GoblinsVsGnome.name = GoblinsVsGnome.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "BlackrockMountain":
                    BlackrockMountain BlackrockMountain = (BlackrockMountain)card;
                    if (BlackrockMountain.name.Contains("2x"))
                    {
                        BlackrockMountain.name = BlackrockMountain.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "TheGrandTournament":
                    TheGrandTournament TheGrandTournament = (TheGrandTournament)card;
                    if (TheGrandTournament.name.Contains("2x"))
                    {
                        TheGrandTournament.name = TheGrandTournament.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "TheLeagueOfExplorer":
                    TheLeagueOfExplorer TheLeagueOfExplorer = (TheLeagueOfExplorer)card;
                    if (TheLeagueOfExplorer.name.Contains("2x"))
                    {
                        TheLeagueOfExplorer.name = TheLeagueOfExplorer.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "WhispersOfTheOldGod":
                    WhispersOfTheOldGod WhispersOfTheOldGod = (WhispersOfTheOldGod)card;
                    if (WhispersOfTheOldGod.name.Contains("2x"))
                    {
                        WhispersOfTheOldGod.name = WhispersOfTheOldGod.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "Karazhan":
                    Karazhan Karazhan = (Karazhan)card;
                    if (Karazhan.name.Contains("2x"))
                    {
                        Karazhan.name = Karazhan.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "MeanStreetsOfGadgetzan":
                    MeanStreetsOfGadgetzan MeanStreetsOfGadgetzan = (MeanStreetsOfGadgetzan)card;
                    if (MeanStreetsOfGadgetzan.name.Contains("2x"))
                    {
                        MeanStreetsOfGadgetzan.name = MeanStreetsOfGadgetzan.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                case "HeroSkin":
                    HeroSkin HeroSkin = (HeroSkin)card;
                    if (HeroSkin.name.Contains("2x"))
                    {
                        HeroSkin.name = HeroSkin.name.Substring(3);
                        listCards.Items.Add(card);
                    }
                    break;
                default:
                    break;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string deck = "";
            foreach (var card in listCards.Items)
            {
                
                var type = card.GetType();
                switch (type.Name)
                {
                    case "Basic":
                        Basic Basic = (Basic)card;
                        if (Basic.name.Contains("2x"))
                        {
                            deck = deck + Basic.cardId + "," + Basic.cardId + ",";
                        }
                        else
                        {
                            deck = deck + Basic.cardId + ",";
                        }
                        break;
                    case "Classic":
                        Classic Classic = (Classic)card;
                        if (Classic.name.Contains("2x"))
                        {
                            deck = deck + Classic.cardId + "," + Classic.cardId + ",";
                        }
                        else
                        {
                            deck = deck + Classic.cardId + ",";
                        }
                        break;
                    case "Promo":
                        Promo Promo = (Promo)card;
                        if (Promo.name.Contains("2x"))
                        {
                            deck = deck + Promo.cardId + "," + Promo.cardId + ",";
                        }
                        else
                        {
                            deck = deck + Promo.cardId + ",";
                        }
                        break;
                    case "Reward":
                        Reward Reward = (Reward)card;
                        if (Reward.name.Contains("2x"))
                        {
                            deck = deck + Reward.cardId + "," + Reward.cardId + ",";
                        }
                        else
                        {
                            deck = deck + Reward.cardId + ",";
                        }
                        break;
                    case "Naxxrama":
                        Naxxrama Naxxrama = (Naxxrama)card;
                        if (Naxxrama.name.Contains("2x"))
                        {
                            deck = deck + Naxxrama.cardId + "," + Naxxrama.cardId + ",";
                        }
                        else
                        {
                            deck = deck + Naxxrama.cardId + ",";
                        }
                        break;
                    case "GoblinsVsGnome":
                        GoblinsVsGnome GoblinsVsGnome = (GoblinsVsGnome)card;
                        if (GoblinsVsGnome.name.Contains("2x"))
                        {
                            deck = deck + GoblinsVsGnome.cardId + "," + GoblinsVsGnome.cardId + ",";
                        }
                        else
                        {
                            deck = deck + GoblinsVsGnome.cardId + ",";
                        }
                        break;
                    case "BlackrockMountain":
                        BlackrockMountain BlackrockMountain = (BlackrockMountain)card;
                        if (BlackrockMountain.name.Contains("2x"))
                        {
                            deck = deck + BlackrockMountain.cardId + "," + BlackrockMountain.cardId + ",";
                        }
                        else
                        {
                            deck = deck + BlackrockMountain.cardId + ",";
                        }
                        break;
                    case "TheGrandTournament":
                        TheGrandTournament TheGrandTournament = (TheGrandTournament)card;
                        if (TheGrandTournament.name.Contains("2x"))
                        {
                            deck = deck + TheGrandTournament.cardId + "," + TheGrandTournament.cardId + ",";
                        }
                        else
                        {
                            deck = deck + TheGrandTournament.cardId + ",";
                        }
                        break;
                    case "TheLeagueOfExplorer":
                        TheLeagueOfExplorer TheLeagueOfExplorer = (TheLeagueOfExplorer)card;
                        if (TheLeagueOfExplorer.name.Contains("2x"))
                        {
                            deck = deck + TheLeagueOfExplorer.cardId + "," + TheLeagueOfExplorer.cardId + ",";
                        }
                        else
                        {
                            deck = deck + TheLeagueOfExplorer.cardId + ",";
                        }
                        break;
                    case "WhispersOfTheOldGod":
                        WhispersOfTheOldGod WhispersOfTheOldGod = (WhispersOfTheOldGod)card;
                        if (WhispersOfTheOldGod.name.Contains("2x"))
                        {
                            deck = deck + WhispersOfTheOldGod.cardId + "," + WhispersOfTheOldGod.cardId + ",";
                        }
                        else
                        {
                            deck = deck + WhispersOfTheOldGod.cardId + ",";
                        }
                        break;
                    case "Karazhan":
                        Karazhan Karazhan = (Karazhan)card;
                        if (Karazhan.name.Contains("2x"))
                        {
                            deck = deck + Karazhan.cardId + "," + Karazhan.cardId + ",";
                        }
                        else
                        {
                            deck = deck + Karazhan.cardId + ",";
                        }
                        break;
                    case "MeanStreetsOfGadgetzan":
                        MeanStreetsOfGadgetzan MeanStreetsOfGadgetzan = (MeanStreetsOfGadgetzan)card;
                        if (MeanStreetsOfGadgetzan.name.Contains("2x"))
                        {
                            deck = deck + MeanStreetsOfGadgetzan.cardId + "," + MeanStreetsOfGadgetzan.cardId + ",";
                        }
                        else
                        {
                            deck = deck + MeanStreetsOfGadgetzan.cardId + ",";
                        }
                        break;
                    case "HeroSkin":
                        HeroSkin HeroSkin = (HeroSkin)card;
                        if (HeroSkin.name.Contains("2x"))
                        {
                            deck = deck + HeroSkin.cardId + "," + HeroSkin.cardId + ",";
                        }
                        else
                        {
                            deck = deck + HeroSkin.cardId + ",";
                        }
                        break;
                    default:
                        break;
                }
            }
            var folder = ApplicationData.Current.LocalFolder;
            var textFile = await folder.CreateFileAsync("cardDecks.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(textFile, deck);
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
