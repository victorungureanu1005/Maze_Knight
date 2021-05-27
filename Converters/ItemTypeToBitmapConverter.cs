using Maze_Knight.Models.Enums.Items;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Maze_Knight.Converters
{

    //Converts the item type of an item in the inventory to a bitmapimage necessary for the binding in the ShadyDealerView and InventoryView; 
    public class ItemTypeToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Set the bitmapUriString root
            string bitmapUriString = "/Content/Icons/";
            //Depending on the ItemType add the file name of the icon to the bitmapUriString
            switch ((ItemTypes)value)
            {
                case ItemTypes.Armour: bitmapUriString += "ArmourIcon_WBackground.png"; break;
                case ItemTypes.Bow: bitmapUriString += "BowIcon_WBackground.png"; break;
                case ItemTypes.Sword: bitmapUriString += "SwordIcon_WBackground.png"; break;
                case ItemTypes.Halberd: bitmapUriString += "HalberdIcon_WBackground.png"; break;
                case ItemTypes.Potion: bitmapUriString += "PotionIcon_WBackground.png"; break;
                case ItemTypes.Rune: bitmapUriString += "RuneIcon_WBackground.png"; break;
            }
            //Create the bitmapUri necessary for the BitmapImage
            Uri bitmapUri = new Uri(bitmapUriString, UriKind.Relative);
            //Returns the BitmapImage
            return new BitmapImage(bitmapUri);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
