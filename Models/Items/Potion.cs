using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Potion;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Potion : Item
    {
        #region Backing Fields
        //Health being restored on use
        private int _restoredHealth;
        //Potion type linked to price and restored health amount
        private PotionTypes _potionType;
        #endregion

        #region Constructor
        public Potion()
        {
            //Setting item types necessary for image binding on inventories and shady dealer
            ItemType = ItemTypes.Potion;
            SetPlayerLevelWhenGenerated();
            //Set potion type
            SetPotionType();
            //Set restored health stat
            SetRestoredHealth();
            //Set potion name
            SetPotionName();
            //Set buy price and sell price
            SetBuyPrice();
            SetSellPrice();
        }
        #endregion

        #region Properties
        //Name is the potion type + "Potion"
        public int RestoredHealth { get => _restoredHealth; set => _restoredHealth = value; }
        public PotionTypes PotionType { get => _potionType; set => _potionType = value; }
        #endregion

        #region Functions
        private void SetPotionType()
        {
            //Setting potion type depending on player level
            if (_playerLevelWhenGenerated <= 6)
            {
                PotionType = (PotionTypes)0;
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                PotionType = (PotionTypes)1;
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                PotionType = (PotionTypes)2;
                return;
            }
        }
        private void SetPotionName()
        {
            ItemName = PotionType.ToString() + " Potion";
        }
        private void SetBuyPrice()
        {
            //Obtain enum for type of potion and then the specific price from price enum for potion type
            PotionBuyPrice potionBuyPriceEnum;
            Enum.TryParse(PotionType.ToString(), out potionBuyPriceEnum);
            ItemBuyPrice = (int)potionBuyPriceEnum;
        }
        private void SetRestoredHealth()
        {
            //Obtain enume for type of potion and then the specific restore health amount from restore health enum for potion type
            PotionBuyPrice potionRestoredHealthEnum;
            Enum.TryParse(PotionType.ToString(), out potionRestoredHealthEnum);
            RestoredHealth = (int)potionRestoredHealthEnum;
        }
        #endregion
    }
}
