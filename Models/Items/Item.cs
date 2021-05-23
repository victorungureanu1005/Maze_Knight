using Maze_Knight.Models.Enums;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Item : BaseModel
    {
        #region Constants
        private protected int SELL_BUY_PRICE_RATIO = 4;
        #endregion
        #region Backing Fields
        private protected int _playerLevelWhenGenerated;
        //IMPLEMENT!!!
        private string _itemNameSuffix;
        private string _itemName;
        //IMPLEMENT!!!
        private int _itemBuyPrice;
        private int _itemSellPrice;

        #endregion

        #region Properties
        public int PlayerLevelWhenGenerated { get => _playerLevelWhenGenerated; set => _playerLevelWhenGenerated = value; }
        public string ItemNameSuffix { get => _itemNameSuffix; set => _itemNameSuffix = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }
        public int ItemBuyPrice { get => _itemBuyPrice; set => _itemBuyPrice = value; }
        public int ItemSellPrice { get => _itemSellPrice; set => _itemSellPrice = value; }

        #endregion

        #region Methods
        private protected void SetSellPrice()
        {
            ItemSellPrice = (int)Math.Round((double)ItemBuyPrice / SELL_BUY_PRICE_RATIO);
        }
        private protected void SetPlayerLevelWhenGenerated()
        {
            PlayerLevelWhenGenerated = PlayerInstances.CurrentPlayerInstance.Level;
        }
        private protected void SetItemNameSuffix()
        {
            ItemNameSuffix = ((ItemNamesRandomizer)RandomGenerator.random.Next(0, Enum.GetNames(typeof(ItemNamesRandomizer)).Length)).ToString();
        }
        #endregion
    }
}
