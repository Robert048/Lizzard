using Windows.Storage;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using System.Collections.Generic;

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
            var cardFile = files.FirstOrDefault(x => x.Name == "cardDecks.txt");
            string result = await FileIO.ReadTextAsync(cardFile);
            result = result.TrimEnd(result[result.Length -1]);
            List<string> cards = result.Split(',').ToList<string>();

        }
    }
}
