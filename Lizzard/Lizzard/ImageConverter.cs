using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Lizzard
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string name = (string)value;
            name = name.Replace(" ", "-");
            name = name.Replace(":", "");
            name = name.Replace("!", "");
            name = name.Replace("'", "");
            name = name.Replace(",", "");
            name = name.Replace(".", "");
            name = name.ToLower();
            return "http://hearthstoneplayers.com/img/cards/" + name + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
