using System;
using Windows.UI.Xaml.Data;

namespace Lizzard
{
    /// <summary>
    /// Converter for Hearthstone image source
    /// </summary>
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

    /// <summary>
    /// Converter for Heroes of the Storm image source of the Heroes
    /// </summary>
    public class ImageConverterHots : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return "http://d1i1jxrdh2kvwy.cloudfront.net/Images/Heroes/Portraits/" + value + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converter for Heroes of the Storm image source of the Maps
    /// </summary>
    public class ImageConverterHotsMaps : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return "http://d1i1jxrdh2kvwy.cloudfront.net/Images/Maps/" + value + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
