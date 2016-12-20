using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Lizzard
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if((string)value == "Hero" || (string)value == "Minion")
            {
                return "http://www.hearthcards.net/cardsexample/card_minion_neutral.png";
            }
            else if ((string)value == "Enchantment" || (string)value == "Spell")
            {
                return "http://www.hearthcards.net/cardsexample/card_spell_neutral.png";
            }
            else if ((string)value == "Weapon")
            {
                return "http://www.hearthcards.net/cardsexample/card_weapon_neutral.png";
            }
            else if ((string)value == "Hero Power")
            {
                return "http://www.hearthcards.net/cardsexample/card_heropower_neutral.png";
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
