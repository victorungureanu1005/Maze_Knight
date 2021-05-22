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
    public class Weapon : Item
    {
        #region Constants
        private int STAT_POINT_BUY_PRICE_INCREASE_FACTOR = 4;
        private int SELL_BUY_PRICE_RATIO = 4;
        private int MAX_NUMBER_OF_STATS_TO_BESTOW = 4;
        #endregion

        #region Backing Fields
        //General information
        private int _playerLevelWhenGenerated;
        private string _swordNameSuffix;
        private string _nameOfWeapon;
        private int _weaponBuyPrice;
        private int _weaponSellPrice;
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
        public Weapon(Player player)
        {
            //Sets player leven when generated to current player instance level. 
            _playerLevelWhenGenerated = PlayerInstances.CurrentPlayerInstance.Level;
            //Identifies and sets stats for the weapon
            GiveStatsToWeapon();
            //Set suffix for the name of the weapon;
            SwordNameSuffix = ((ItemNamesRandomizer)RandomGenerator.random.Next(0, Enum.GetNames(typeof(ItemNamesRandomizer)).Length + 1)).ToString();
            //Buy price is determined by adding all the bonus points and multiplying with the const indicating price/point. Some stats have bigger value therefore multiplied with 2 or 4. 
            WeaponBuyPrice = (MinDamageBonus * 2 + MaxDamageBonus + SwordSkillBonus + BowSkillBonus + HalberdSkillBonus) * STAT_POINT_BUY_PRICE_INCREASE_FACTOR;
            WeaponSellPrice = (int)Math.Round((double)WeaponBuyPrice / SELL_BUY_PRICE_RATIO);
        }
        #endregion

        #region Properties
        //General information
        public string SwordNameSuffix { get => _swordNameSuffix; set => _swordNameSuffix = value; }
        public string NameOfWeapon { get => _nameOfWeapon; set => _nameOfWeapon = value; }
        public int WeaponBuyPrice { get => _weaponBuyPrice; set => _weaponBuyPrice = value; }
        public int WeaponSellPrice { get => _weaponSellPrice; set => _weaponSellPrice = value; }
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

        #endregion

        #region Bestow Weapon Stat Methods
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
            }
            if (_playerLevelWhenGenerated > 12)
            {
                MinDamageBonus += RandomGenerator.random.Next(13, 25);
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
            }
            if (_playerLevelWhenGenerated > 12)
            {
                MaxDamageBonus += RandomGenerator.random.Next(30, 80);
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
            }
            if (_playerLevelWhenGenerated > 12)
            {
                SwordSkillBonus += RandomGenerator.random.Next(13, 20);
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
            }
            if (_playerLevelWhenGenerated > 12)
            {
                BowSkillBonus += RandomGenerator.random.Next(13, 20);
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
            }
            if (_playerLevelWhenGenerated > 12)
            {
                HalberdSkillBonus += RandomGenerator.random.Next(13, 20);
            }
        }
        #endregion
    }
}
