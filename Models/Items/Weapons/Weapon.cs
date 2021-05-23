using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Maze_Knight.StaticClasses;
using Maze_Knight.Models.Enums;

namespace Maze_Knight.Models.Items
{
    public abstract class Weapon : Item
    {
        #region Constants
        //Buy price increase factor for price, further down to be adjusted as well
        private int STAT_POINT_BUY_PRICE_INCREASE_FACTOR = 4;
        //Max number of stats to bestow per number. Random value will be used, but a max should be establishedfor this item type
        private int MAX_NUMBER_OF_STATS_TO_BESTOW = 4;
        #endregion

        #region Backing Fields
        //General information
        private WeaponTypes _weaponType;
        private WeaponSubTypes _weaponSubType;

        //MinMax damage bonuses if equiped 
        private int _minDamageBonus;
        private int _maxDamageBonus;

        //Skill bonuses if equiped 
        private int _swordSkillBonus;
        private int _bowSkillBonus;
        private int _halberdSkillBonus;
        #endregion

        #region Constructor
        public Weapon()
        {
            //Sets player level when generated to current player instance level. 
            SetPlayerLevelWhenGenerated();
            //Set weapon type depending on class generated
            SetWeaponType();
            //Identifies and sets stats for the weapon
            GiveStatsToWeapon();
            //Set suffix for the name of the weapon; The full name is set when using the constructor in the derivate as the subtype generated is relevant!
            SetItemNameSuffix();
            //Buy price is determined by adding all the bonus points and multiplying with the const indicating price/point. Some stats have bigger value therefore multiplied with 2 or 4. 
            SetWeaponBuyPrice(); 
            SetSellPrice();
        }
        #endregion

        #region Properties
        //General information
        public WeaponTypes WeaponType { get => _weaponType; set => _weaponType = value; }
        public WeaponSubTypes WeaponSubType { get => _weaponSubType; set => _weaponSubType = value; }

        //MinMax damage bonuses
        public int MinDamageBonus { get => _minDamageBonus; set => _minDamageBonus = value; }
        public int MaxDamageBonus { get => _maxDamageBonus; set => _maxDamageBonus = value; }

        //Skill bonuses
        public int SwordSkillBonus { get => _swordSkillBonus; set => _swordSkillBonus = value; }
        public int BowSkillBonus { get => _bowSkillBonus; set => _bowSkillBonus = value; }
        public int HalberdSkillBonus { get => _halberdSkillBonus; set => _halberdSkillBonus = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Setting Weapon Type needs to be done here rather than in the derivate class, as we need to identify the type already at this base classe's level in order to run some methods
        /// </summary>
        private void SetWeaponType()
        {
            WeaponTypes weaponTypes;
            //this here is the class being instantiated (sword, bow, hallberd)all derivates of the weapon class
            Enum.TryParse(this.GetType().Name, out weaponTypes);
            WeaponType = weaponTypes;
        }
        private void GiveStatsToWeapon()
        {
            //Gets the number of times additional stats need to be added to the weapon
            int numberOfStatsOnWeapon = RandomGenerator.random.Next(1, MAX_NUMBER_OF_STATS_TO_BESTOW);
            for (int i = 0; i < numberOfStatsOnWeapon; i++)
            {
                //Randomly choose between the stats to be bestowed and bestow according to Weapon type
                int bestowStatsIndexer = RandomGenerator.random.Next(0, 3);
                switch (bestowStatsIndexer)
                {
                    case 0: BestowMinDamageBonus(); break;
                    case 1: BestowMaxDamageBonus(); break;
                    case 2:
                        switch (this.WeaponType)
                        {
                            case WeaponTypes.Sword: BestowSwordSkillBonus(); break;
                            case WeaponTypes.Bow: BestowBowSkillBonus(); break;
                            case WeaponTypes.Halberd: BestowHalberdSkillBonus(); break;
                        }
                        break;
                }
            }
        }
        private void SetWeaponBuyPrice()
        {
            ItemBuyPrice = (MinDamageBonus * 2 + MaxDamageBonus + SwordSkillBonus * 4 + BowSkillBonus * 4 + HalberdSkillBonus * 4) * STAT_POINT_BUY_PRICE_INCREASE_FACTOR;
        }
        private protected void SetWeaponName()
        {
            ItemName = WeaponSubType.ToString() + " of " + ItemNameSuffix;
        }
        #endregion

        #region Bestow Weapon Stat Methods
        //Depending on player level, the weapon type being instantiated will have different values of bestowed stats
        private void BestowMinDamageBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                MinDamageBonus += RandomGenerator.random.Next(1, 3);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                MinDamageBonus += RandomGenerator.random.Next(5, 12);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                MinDamageBonus += RandomGenerator.random.Next(13, 25);
                return;
            }
        }
        private void BestowMaxDamageBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                MaxDamageBonus += RandomGenerator.random.Next(10, 12);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                MaxDamageBonus += RandomGenerator.random.Next(12, 30);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                MaxDamageBonus += RandomGenerator.random.Next(30, 80);
                return;
            }
        }
        private void BestowSwordSkillBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                SwordSkillBonus += RandomGenerator.random.Next(1, 7);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                SwordSkillBonus += RandomGenerator.random.Next(7, 13);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                SwordSkillBonus += RandomGenerator.random.Next(13, 20);
                return;
            }
        }
        private void BestowBowSkillBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                BowSkillBonus += RandomGenerator.random.Next(1, 7);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                BowSkillBonus += RandomGenerator.random.Next(7, 13);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                BowSkillBonus += RandomGenerator.random.Next(13, 20);
                return;
            }
        }
        private void BestowHalberdSkillBonus()
        {
            if (_playerLevelWhenGenerated <= 6)
            {
                HalberdSkillBonus += RandomGenerator.random.Next(1, 7);
                return;
            }
            if (_playerLevelWhenGenerated <= 12)
            {
                HalberdSkillBonus += RandomGenerator.random.Next(7, 13);
                return;
            }
            if (_playerLevelWhenGenerated > 12)
            {
                HalberdSkillBonus += RandomGenerator.random.Next(13, 20);
                return;
            }
        }
        #endregion
    }
}
