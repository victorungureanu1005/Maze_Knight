using Maze_Knight.Models.Enums.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models.Items
{
    public class Armour : Item
    {
        #region Backing Fields
        //General information
        private string _armourNameSuffix;
        private ArmourTypes _armourType;

        //Resistance bonuses if equiped
        private int _humanoidResistanceBonus;
        private int _mysticalResistanceBonus;

        //Health bonus if equiped
        private int _healthBonus;
        #endregion

        #region Properties
        //General information
        public string ArmourNameSuffix { get => _armourNameSuffix; set => _armourNameSuffix=value; }
        public ArmourTypes ArmourType { get => _armourType; set => _armourType=value; }

        //Name of armour by establishing the armour type, adding "of" and a suffix from the ItemNamesRandomizer enum
        public string NameOfArmour { get => ArmourType.ToString() + " of " + ArmourNameSuffix; }

        //Resistance bonuses
        public int HumanoidResistanceBonus { get => _humanoidResistanceBonus; set => _humanoidResistanceBonus=value; }
        public int MysticalResistanceBonus { get => _mysticalResistanceBonus; set => _mysticalResistanceBonus=value; }

        //Health bonus
        public int HealthBonus { get => _healthBonus; set => _healthBonus=value; }

        #endregion
    }
}
