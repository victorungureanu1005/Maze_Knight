using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Rune : Item
    {
        #region Constants
        //Constants for all runes
        private const int RUNE_NUMBER_OF_TURNS_ACTIVE = 3;
        private const int RUNE_BUY_PRICE = 200;
        private const string RUNE_NAME = "Magic Rune";
        #endregion

        #region Backing Fields
        private int _runeNumberOfTurnsActive;
        #endregion

        #region Constructor
        public Rune()
        {
            //Set properties as per constants above
            ItemName = RUNE_NAME;
            RuneNumberOfTurnsActive = RUNE_NUMBER_OF_TURNS_ACTIVE;
            ItemBuyPrice = RUNE_BUY_PRICE;
            SetSellPrice();
        }
        #endregion

        #region Properties
        public int RuneNumberOfTurnsActive { get => _runeNumberOfTurnsActive; set => _runeNumberOfTurnsActive = value; }
        #endregion
    }
}
