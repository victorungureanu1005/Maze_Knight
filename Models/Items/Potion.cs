using Maze_Knight.Models.Enums.Items;
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

        private int _restoredHealth;
        private PotionTypes _potionType;
        #endregion

        #region Properties
        //Name is the potion type + "Potion"
        public string PotionName { get => PotionType.ToString() + " Potion"; }
        public int RestoredHealth { get => _restoredHealth; set => _restoredHealth=value; }
        public PotionTypes PotionType { get => _potionType; set => _potionType=value; }
        #endregion 
    }
}
