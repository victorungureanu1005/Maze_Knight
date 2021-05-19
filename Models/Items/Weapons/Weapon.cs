using Maze_Knight.Models.Enums.Items;
using Maze_Knight.Models.Enums.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Weapon : Item
    {
        #region Backing Fields
        //General information
        private string _swordNameSuffix;
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
        public Weapon()
        {

        }
        #endregion

        #region Properties
        //General information
        public string SwordNameSuffix { get => _swordNameSuffix; set => _swordNameSuffix=value; }
        public int WeaponBuyPrice { get => _weaponBuyPrice; set => _weaponBuyPrice=value; }
        public int WeaponSellPrice { get => _weaponSellPrice; set => _weaponSellPrice=value; }
        public WeaponTypes WeaponType { get => _weaponType; set => _weaponType=value; }
        public WeaponSubTypes WeaponSubType { get => _weaponSubType; set => _weaponSubType=value; }

        //Name of weapon by establishing the weapon sub type, adding of and a suffix from the ItemNamesRandomizer enum
        public string NameOfWeapon { get => WeaponSubType.ToString() + " of " + SwordNameSuffix; }

        //MinMax damage bonuses
        public int MinDamageBonus { get => _minDamageBonus; set => _minDamageBonus=value; }
        public int MaxDamageBonus { get => _maxDamageBonus; set => _maxDamageBonus=value; }

        //Skill bonuses
        public int SwordSkillBonus { get => _swordSkillBonus; set => _swordSkillBonus=value; }
        public int BowSkillBonus { get => _bowSkillBonus; set => _bowSkillBonus=value; }
        public int HalberdSkillBonus { get => _halberdSkillBonus; set => _halberdSkillBonus=value; }


        #endregion
    }
}
