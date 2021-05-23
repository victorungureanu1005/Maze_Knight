using Maze_Knight.Models.Enums;
using Maze_Knight.Models.Enums.Items;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Armour : Item
    {
        #region Constants
        //Buy price increase factor for price, further down to be adjusted as well
        private int STAT_POINT_BUY_PRICE_INCREASE_FACTOR = 3;
        //Max number of stats to bestow per number. Random value will be used, but a max should be establishedfor this item type
        private int MAX_NUMBER_OF_STATS_TO_BESTOW = 4;
        #endregion

        #region Backing Fields
        //General information
        private ArmourTypes _armourType;

        //Resistance bonuses if equiped
        private int _humanoidResistanceBonus;
        private int _mysticalResistanceBonus;

        //Health bonus if equiped
        private int _healthBonus;
        #endregion

        #region Constructor
        public Armour()
        {
            //Sets player level when generated to current player instance level. 
            SetPlayerLevelWhenGenerated();
            //Set ArmourType
            SetArmourType();
            //Identifies and sets stats for the armour
            GiveStatsToArmour();
            //Set suffix for the name of the armour and set name accordingly
            SetItemNameSuffix();
            SetArmourName();
            //Set prices
            SetArmourBuyPrice();
            SetSellPrice();
        }
        #endregion

        #region Properties
        //General information
        public ArmourTypes ArmourType { get => _armourType; set => _armourType = value; }

        //Resistance bonuses
        public int HumanoidResistanceBonus { get => _humanoidResistanceBonus; set => _humanoidResistanceBonus = value; }
        public int MysticalResistanceBonus { get => _mysticalResistanceBonus; set => _mysticalResistanceBonus = value; }

        //Health bonus
        public int HealthBonus { get => _healthBonus; set => _healthBonus = value; }
        #endregion

        #region Functions
        private void GiveStatsToArmour()
        {
            //Gets the number of times additional stats need to be added to the armour
            int numberOfStatsOnWeapon = RandomGenerator.random.Next(1, MAX_NUMBER_OF_STATS_TO_BESTOW);
            for (int i = 0; i < numberOfStatsOnWeapon; i++)
            {
                //Randomly choose between the stats to be bestowed and bestow according to Weapon type
                int bestowStatsIndexer = RandomGenerator.random.Next(0, 3);
                switch (bestowStatsIndexer)
                {
                    case 0: BestowHumanoidResistanceBonus(); break;
                    case 1: BestowMysticalResistanceBonus(); break;
                    case 2: BestowHealthBonus(); break;
                }
            }
        }
        private protected void SetArmourName()
        {
            ItemName = ArmourType.ToString() + " of " + ItemNameSuffix;
        }
        //Set random Armour Type from specific range depending on level. 
        private void SetArmourType()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                ArmourType = (ArmourTypes)RandomGenerator.random.Next(0, 2);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                ArmourType = (ArmourTypes)RandomGenerator.random.Next(2, 4);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                ArmourType = (ArmourTypes)4;
                return;
            }
        }
        private void SetArmourBuyPrice()
        {
            //Buy price is determined by adding all the bonus points and multiplying with the const indicating price/point. Some stats have bigger value
            ItemBuyPrice = (HumanoidResistanceBonus * 10 + MysticalResistanceBonus * 10 + HealthBonus) * STAT_POINT_BUY_PRICE_INCREASE_FACTOR;
        }
        #endregion

        #region Bestow Weapon Stat Methods
        //Depending on player level, the armour being instantiated will have different values of bestowed stats
        private void BestowHumanoidResistanceBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                HumanoidResistanceBonus += RandomGenerator.random.Next(1, 7);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                HumanoidResistanceBonus += RandomGenerator.random.Next(7, 13);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                HumanoidResistanceBonus += RandomGenerator.random.Next(13, 20);
                return;
            }
        }
        private void BestowMysticalResistanceBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                MysticalResistanceBonus += RandomGenerator.random.Next(1, 7);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                MysticalResistanceBonus += RandomGenerator.random.Next(7, 13);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                MysticalResistanceBonus += RandomGenerator.random.Next(13, 20);
                return;
            }
        }
        private void BestowHealthBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                HealthBonus += RandomGenerator.random.Next(20, 100);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                HealthBonus += RandomGenerator.random.Next(100, 500);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                HealthBonus += RandomGenerator.random.Next(500, 2000);
                return;
            }
        }
        #endregion
    }
}
