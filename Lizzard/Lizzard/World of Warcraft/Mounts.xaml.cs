﻿using Newtonsoft.Json;
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

namespace Lizzard.World_of_Warcraft
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Mounts : Page
    {
        public Mounts()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            loadMounts();
        }

        private async void loadMounts()
        {
            WoWApi call = new WoWApi();
            var result = await call.get("mount/?locale=en_GB&apikey=4v8q8ry9kymcbmfgjx7h7a5ufhqn3259");
            var jsonresult = JsonConvert.DeserializeObject<RootObjectMount>(result);
            foreach (Mount m in jsonresult.mounts)
            {
                m.icon = "http://wow.zamimg.com/images/wow/icons/large/" + m.icon + ".jpg";
                gridView.Items.Add(m);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}