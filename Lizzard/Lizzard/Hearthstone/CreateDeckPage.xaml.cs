using Newtonsoft.Json;
using System;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lizzard.Hearthstone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
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
            var newFolder = await folder.CreateFolderAsync("NewFolder", CreationCollisionOption.OpenIfExists);
            var files = await newFolder.GetFilesAsync();
            var cardFile = files.FirstOrDefault(x => x.Name == "cards.txt");
            var result = await FileIO.ReadTextAsync(cardFile);
            var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
